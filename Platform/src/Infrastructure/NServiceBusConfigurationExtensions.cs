using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NServiceBus;
using NServiceBus.Metrics.ServiceControl;
using Microsoft.Azure.Cosmos;
using Platform.Domain.Contracts;

namespace Infrastructure
{
    public static class NServiceBusConfigurationExtensions
    {
        private static IHostBuilder UseSharedNServiceBusForProduction(
          this IHostBuilder hostBuilder,
          string endpointName,
          Action<IConfiguration, ServiceBusTriggeredEndpointConfiguration> configurationAction = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(endpointName);
            return hostBuilder.UseNServiceBus(endpointName, (configuration, endpointConfiguration) =>
            {
                // Try to obtain fully qualified namespace from configuration or environment variables
                var fqn = configuration["AzureServiceBus:FullyQualifiedNamespace"] ??
                          Environment.GetEnvironmentVariable("AzureServiceBus__FullyQualifiedNamespace") ??
                          Environment.GetEnvironmentVariable("AzureServiceBus:FullyQualifiedNamespace");

                if (string.IsNullOrWhiteSpace(fqn))
                {
                    throw new InvalidOperationException("Production configuration requires either AzureServiceBus:FullyQualifiedNamespace or a connection string in configuration.");
                }

                // Note: Azure Functions Worker with Service Bus has limitations with managed identity
                // TODO: Check MI support in this latest version

                // Log and apply common configuration
                Console.WriteLine($"[NServiceBus] Production mode: using namespace {fqn}");

                ApplySharedEndpointConfiguration(endpointConfiguration, configuration);

                // Environment-specific: configure license for production
                var license = configuration["NSERVICEBUS_LICENSE"] ?? Environment.GetEnvironmentVariable("NSERVICEBUS_LICENSE");
                var advanced = endpointConfiguration.AdvancedConfiguration;
                advanced.License(license);
            });
        }

        private static IHostBuilder UseSharedNServiceBusForDevelopment(
            this IHostBuilder hostBuilder,
            string endpointName,
            Action<IConfiguration, ServiceBusTriggeredEndpointConfiguration> configurationAction = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(endpointName);

            return hostBuilder.UseNServiceBus(endpointName, (configuration, endpointConfiguration) =>
            {
                // Get connection string from configuration
                var connectionString = configuration["AzureWebJobsServiceBus"];

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new InvalidOperationException(
                        "AzureServiceBus connection string is missing in configuration. " +
                        "Add it to local.settings.json");
                }

                var cosmosDbConnection = configuration["CosmosDbConnectionString"];
                if (string.IsNullOrWhiteSpace(cosmosDbConnection))
                {
                    throw new InvalidOperationException(
                        "CosmosDbConnectionString is missing in configuration. " +
                        "Add it to local.settings.json");
                }
                var cosmosDbDatabase = "PlatformIntegrationDB";
                var cosmosDbContainer = "PlatformMessagev1";
                var containerPartitionKey = "/CorrelationId";

                var persistence = endpointConfiguration.AdvancedConfiguration.UsePersistence<CosmosPersistence>()
.CosmosClient(new CosmosClient(cosmosDbConnection))
.DatabaseName(cosmosDbDatabase);

                persistence.DefaultContainer(
          containerName: cosmosDbContainer,
          partitionKeyPath: containerPartitionKey);
                var tx = persistence.TransactionInformation();
                tx.ExtractPartitionKeyFromMessage<IProvideCorrelationId>(providerId =>
                {
                    return new PartitionKey(providerId.CorrelationId.ToString());
                });
                ApplySharedEndpointConfiguration(endpointConfiguration, configuration, true);



                //  configurationAction?.Invoke(configuration, endpointConfiguration);
            });
        }

        public static IHostBuilder NServiceBusEnvironmentConfiguration(
            this IHostBuilder hostBuilder,
            string endpointName,
            Action<IConfiguration, ServiceBusTriggeredEndpointConfiguration> configurationAction = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(endpointName);
            // Decide at the host-builder level which concrete configuration helper to use
            var environment = Environment.GetEnvironmentVariable("AZURE_FUNCTIONS_ENVIRONMENT") ??
                              Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ??
                              "Development";

            Console.WriteLine($"[NServiceBus] Auto-configuring for environment: {environment}");

            if (environment.Equals("Production", StringComparison.OrdinalIgnoreCase))
            {
                return hostBuilder.UseSharedNServiceBusForProduction(endpointName, configurationAction);
            }
            else
            {
                return hostBuilder.UseSharedNServiceBusForDevelopment(endpointName, configurationAction);
            }


        }

        private static void ApplySharedEndpointConfiguration(ServiceBusTriggeredEndpointConfiguration endpointConfiguration, IConfiguration configuration, bool disableRetries = false)
        {

            endpointConfiguration.UseSerialization<SystemJsonSerializer>();
            var advanced = endpointConfiguration.AdvancedConfiguration;
            advanced.AuditSagaStateChanges("audit");
            advanced.SendFailedMessagesTo("error");
            advanced.AuditProcessedMessagesTo("audit");
            var metrics = advanced.EnableMetrics();
            metrics.SendMetricDataToServiceControl("particular.monitoring", TimeSpan.FromSeconds(10));
            //advanced.SendHeartbeatTo("Particular.ServiceControl");



            // Configure message conventions
            var conventions = advanced.Conventions();
            conventions.DefiningEventsAs(type => type.Namespace != null && type.Namespace.EndsWith("Events"));
            conventions.DefiningCommandsAs(type => type.Namespace != null && type.Namespace.EndsWith("Commands"));
            conventions.DefiningMessagesAs(type => type.Namespace != null && type.Namespace.EndsWith("Messages"));

            if (disableRetries)
            {
                advanced.Recoverability().Delayed(delayed =>
                {
                    delayed.NumberOfRetries(0);
                    delayed.TimeIncrease(TimeSpan.FromSeconds(30));
                });
                advanced.Recoverability().Immediate(immediate => immediate.NumberOfRetries(0));
            }
        }
    }
}
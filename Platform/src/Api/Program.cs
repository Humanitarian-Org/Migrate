using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Platform.Domain.Managers;
using Platform.Domain.Managers.Services.PlatformIntegrationDb;
using Microsoft.Azure.Cosmos;
using Infrastructure;
using NServiceBus;

[assembly: NServiceBusTriggerFunction("ASBPlatformMessageProcessor")]
var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {

        services.AddSingleton(s => new CosmosClient(
            Environment.GetEnvironmentVariable("CosmosDbConnectionString") ?? "your-cosmos-connection-string"
        ));
        services.AddScoped(s => 
        {
            var cosmosClient = s.GetRequiredService<CosmosClient>();
            return new Platform.Domain.Managers.Services.CosmosService.CosmosRepository(
                cosmosClient, 
                "PlatformIntegrationDB", 
                "PlatformMessagev1"
            );
        });
        services.AddScoped<IBulkBeneficiaryUploadManager, BulkBeneficiaryUploadManager>();
        services.AddScoped<IPlatformRepository, PlatformRepository>();
    })
    .NServiceBusEnvironmentConfiguration("ASBPlatformMessageProcessor")
    .Build();

//Ensure CosmosDB database and container exist before starting the host
var cosmosClient = host.Services.GetRequiredService<CosmosClient>();
CosmosDbInitializer.EnsureDbAndContainerAsync(
    cosmosClient,
    "PlatformIntegrationDB",
    "PlatformMessagev1",
    "/CorrelationId"
).GetAwaiter().GetResult();

host.Run();
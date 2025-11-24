using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Beneficiary.Domain.Managers;
using Beneficiary.Domain.Managers.Services.BeneficiaryIntegrationDb;
using Microsoft.Azure.Cosmos;
using Infrastructure;
using NServiceBus;
[assembly: NServiceBusTriggerFunction("ASBBeneficiaryMessageProcessor")]
var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        // CosmosDB
        services.AddSingleton(s => new CosmosClient(
            Environment.GetEnvironmentVariable("CosmosDbConnectionString") ?? "your-cosmos-connection-string"
        ));
        
        // Register the new BeneficiaryManager
        services.AddScoped<IBeneficiaryManager, BeneficiaryManager>();
        
        // Legacy services (if still needed by other functions)
        services.AddScoped(s => new Beneficiary.Domain.Managers.Services.CosmosService.CosmosRepository());
        services.AddScoped<IBeneficiaryRepository, BeneficiaryRepository>();
    })
    .NServiceBusEnvironmentConfiguration("ASBBeneficiaryMessageProcessor")
    .Build();

//Ensure CosmosDB database and container exist before starting the host
var cosmosClient = host.Services.GetRequiredService<CosmosClient>();
CosmosDbInitializer.EnsureDbAndContainerAsync(
    cosmosClient,
    "BeneficiaryIntegrationDB",
    "BeneficiaryMessagev1",
    "/CorrelationId"
).GetAwaiter().GetResult();

host.Run();
using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Medical.Domain.Managers;
using Medical.Domain.Managers.Services.MedicalIntegrationDb;
using Microsoft.Azure.Cosmos;
using Infrastructure;
using NServiceBus;
[assembly: NServiceBusTriggerFunction("ASBMedicalMessageProcessor")]
var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {

        services.AddSingleton(s => new CosmosClient(
            Environment.GetEnvironmentVariable("CosmosDbConnectionString") ?? "your-cosmos-connection-string"
        ));
        services.AddScoped(s => new Medical.Domain.Managers.Services.CosmosService.CosmosRepository(s.GetRequiredService<CosmosClient>(), Environment.GetEnvironmentVariable("CosmosDbDatabase") ?? "MedicalIntegrationDB", Environment.GetEnvironmentVariable("CosmosDbContainer") ?? "MedicalMessagev1"));
        services.AddScoped<IIntakeManager, IntakeManager>();
        services.AddScoped<IMedicalRepository, MedicalRepository>();
    })
    .NServiceBusEnvironmentConfiguration("ASBMedicalMessageProcessor")
    .Build();

//Ensure CosmosDB database and container exist before starting the host
var cosmosClient = host.Services.GetRequiredService<CosmosClient>();
CosmosDbInitializer.EnsureDbAndContainerAsync(
    cosmosClient,
    "MedicalIntegrationDB",
    "MedicalMessagev1",
    "/CorrelationId"
).GetAwaiter().GetResult();

host.Run();

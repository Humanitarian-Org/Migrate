using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Cosmos;
using Infrastructure;
using NServiceBus;

[assembly: NServiceBusTriggerFunction("ASBMedicalResponseWorker")]
var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
      .ConfigureServices(services =>
    {


        services.AddSingleton(s => new CosmosClient(
            Environment.GetEnvironmentVariable("CosmosDbConnectionString") ?? "your-cosmos-connection-string"
        ));
        //services.AddScoped(s => new Domain.Managers.Services.CosmosService.CosmosRepository(s.GetRequiredService<CosmosClient>(), Environment.GetEnvironmentVariable("CosmosDbDatabase") ?? "MedicalIntegrationDB", Environment.GetEnvironmentVariable("CosmosDbContainer") ?? "MedicalMessagev1"));

    })
    .NServiceBusEnvironmentConfiguration("ASBMedicalResponseWorker")
    .Build();

host.Run();
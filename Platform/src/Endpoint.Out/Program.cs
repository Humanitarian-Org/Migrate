using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Cosmos;
using Infrastructure;
using NServiceBus;

[assembly: NServiceBusTriggerFunction("ASBPlatformResponseWorker")]
var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
      .ConfigureServices(services =>
    {


        services.AddSingleton(s => new CosmosClient(
            Environment.GetEnvironmentVariable("CosmosDbConnectionString") ?? "your-cosmos-connection-string"
        ));
        //services.AddScoped(s => new Platform.Domain.Managers.Services.CosmosService.CosmosRepository());

    })
    .NServiceBusEnvironmentConfiguration("ASBPlatformResponseWorker")
    .Build();

host.Run();
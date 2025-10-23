using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Cosmos;
using Infrastructure;
using NServiceBus;

[assembly: NServiceBusTriggerFunction("ASBBeneficiaryResponseWorker")]
var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
      .ConfigureServices(services =>
    {


        services.AddSingleton(s => new CosmosClient(
            Environment.GetEnvironmentVariable("CosmosDbConnectionString") ?? "your-cosmos-connection-string"
        ));
        //services.AddScoped(s => new Beneficiary.Domain.Managers.Services.CosmosService.CosmosRepository());

    })
    .NServiceBusEnvironmentConfiguration("ASBBeneficiaryResponseWorker")
    .Build();

host.Run();
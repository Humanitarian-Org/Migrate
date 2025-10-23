using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Cosmos;
using Infrastructure;
using NServiceBus;
using Beneficiary.Domain.Managers;

[assembly: NServiceBusTriggerFunction("ASBBeneficiaryMessageWorker")]
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

        // TODO: Add other domain services as needed
        // services.AddScoped<IBeneficiaryRepository, BeneficiaryRepository>();
        // services.AddScoped<INotificationService, NotificationService>();
    })
    .NServiceBusEnvironmentConfiguration("ASBBeneficiaryMessageWorker")
    .Build();

host.Run();
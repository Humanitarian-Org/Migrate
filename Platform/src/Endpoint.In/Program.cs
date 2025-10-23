using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Cosmos;
using Infrastructure;
using NServiceBus;
using Platform.Domain.Services;
using Platform.Infrastructure.Services;

[assembly: NServiceBusTriggerFunction("ASBPlatformMessageWorker")]
var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
      .ConfigureServices(services =>
    {
      // HTTP Client for SignalR service
      services.AddHttpClient<ISignalRService, SignalRService>();

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

      // Register BulkBeneficiaryUploadManager and its dependencies
      services.AddScoped<Platform.Domain.Managers.Services.PlatformIntegrationDb.IPlatformRepository, Infrastructure.PlatformRepository>();
      services.AddScoped<Platform.Domain.Managers.IBulkBeneficiaryUploadManager, Platform.Domain.Managers.BulkBeneficiaryUploadManager>();

    })
    .NServiceBusEnvironmentConfiguration("ASBPlatformMessageWorker")
    .Build();

host.Run();
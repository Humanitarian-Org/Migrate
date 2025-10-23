using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using NServiceBus;

using Platform.Domain.Contracts.Commands;
using Platform.Domain.Managers.Services.CosmosService;


namespace Endpoint.In.Handlers
{
    public class SystemConfigurationRequestedHandler : IHandleMessages<ConfigureSystemCommand>
    {
        public async Task Handle(ConfigureSystemCommand command, IMessageHandlerContext context)
        {
            // call manager to create system configuration in dataverse
            // does it generate a system configuration id?
            string configurationId = Guid.NewGuid().ToString();
            await UpdateSystemConfigurationDocumentAsync(configurationId, command.CorrelationId, command.DocId, context);
            // publish SystemConfigurationCompleted event
            var configurationCompletedEvent = new Platform.Domain.Contracts.Events.SystemConfigurationCompleted
            {
                CorrelationId = command.CorrelationId,
                SystemId = command.SystemId,
                ConfigurationId = configurationId,
                CompletedAt = DateTimeOffset.UtcNow,
                Success = true,
                Message = "System configuration completed successfully"
            };

            await context.Publish(configurationCompletedEvent);
            //return Task.CompletedTask;
        }

        private static async Task UpdateSystemConfigurationDocumentAsync(string configurationId, string correlationId, string docId, IMessageHandlerContext context)
        {
            var session = context.SynchronizedStorageSession.CosmosPersistenceSession();

            var configureSystemRequest = await session.Container.ReadItemAsync<ConfigureSystemRequest>(docId, new PartitionKey(correlationId), cancellationToken: context.CancellationToken);
            configureSystemRequest.Resource.IsProcessed = "1";
            configureSystemRequest.Resource.ConfigurationId = configurationId;
            // update the document atomically with consuming the message
            session.Batch.ReplaceItem(docId, configureSystemRequest.Resource);
        }
    }
}
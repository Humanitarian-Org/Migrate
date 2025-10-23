using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using NServiceBus;

using Medical.Domain.Contracts.Commands;
using Medical.Domain.Managers.Services.CosmosService;


namespace Endpoint.In.Handlers
{
    public class CaseRegistrationRequestedHandler : IHandleMessages<RegisterCaseCommand>
    {
        public async Task Handle(RegisterCaseCommand command, IMessageHandlerContext context)
        {
            // call manager to create case in dataverse
            // does it generate a case id?
            string caseId = Guid.NewGuid().ToString();
            await UpdateHealthCaseDocumentAsync(caseId, command.CorrelationId, command.DocId, context);
            // publish CaseRegistrationCompleted event
            var caseRegisteredEvent = new Medical.Domain.Contracts.Events.CaseRegistrationCompleted
            {
                CorrelationId = command.CorrelationId,
                CaseId = caseId,
                CreatedAt = DateTimeOffset.UtcNow
            };

            await context.Publish(caseRegisteredEvent);
            //return Task.CompletedTask;
        }

        private static async Task UpdateHealthCaseDocumentAsync(string caseId, string correlationId, string docId, IMessageHandlerContext context)
        {
            var session = context.SynchronizedStorageSession.CosmosPersistenceSession();

            var registerHealthCaseRequest = await session.Container.ReadItemAsync<RegisterHealthCaseRequest>(docId, new PartitionKey(correlationId), cancellationToken: context.CancellationToken);
            registerHealthCaseRequest.Resource.IsProcessed = "1";
            registerHealthCaseRequest.Resource.CaseId = caseId;
            // update the document atomically with consuming the message
            session.Batch.ReplaceItem(docId, registerHealthCaseRequest.Resource);
        }
    }
}

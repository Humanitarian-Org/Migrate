using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using NServiceBus;
using Medical.Domain.Contracts.Events;
using Medical.Domain.Managers.Services.CosmosService;

namespace Endpoint.In.Handlers
{
    public class DeleteHealthCaseRequestedHandler : IHandleMessages<DeleteHealthCaseRequested>
    {
        public async Task Handle(DeleteHealthCaseRequested message, IMessageHandlerContext context)
        {
            // Simulate delete logic (e.g., delete case in dataverse)
            await DeleteCaseAsync(message.CaseId, message.CorrelationId, message.DocId, context);

            // Publish DeleteHealthCaseCompleted event
            var deleteHealthCaseCompletedEvent = new DeleteHealthCaseCompleted
            {
                CorrelationId = message.CorrelationId,
                CaseId = message.CaseId,
                PatientId = message.PatientId,
                ClinicId = message.ClinicId,
                CreatedAt = DateTimeOffset.UtcNow,
                DocId = message.DocId
            };

            await context.Publish(deleteHealthCaseCompletedEvent);
        }

        private static async Task DeleteCaseAsync(string caseId, string correlationId, string docId, IMessageHandlerContext context)
        {
            var session = context.SynchronizedStorageSession.CosmosPersistenceSession();
            var deleteHealthCaseRequest = await session.Container.ReadItemAsync<Medical.Domain.Managers.Services.CosmosService.DeleteCachedHealthCaseRequest>(docId, new PartitionKey(correlationId), cancellationToken: context.CancellationToken);
            deleteHealthCaseRequest.Resource.IsProcessed = "1"; // Mark as deleted
            deleteHealthCaseRequest.Resource.CaseId = caseId;
            session.Batch.ReplaceItem(docId, deleteHealthCaseRequest.Resource);
        }
    }
}

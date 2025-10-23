using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using NServiceBus;
using Medical.Domain.Contracts.Events;
using Medical.Domain.Managers.Services.CosmosService;

namespace Endpoint.In.Handlers
{
    public class FinalizeCaseRequestedHandler : IHandleMessages<FinalizeCaseRequested>
    {
        public async Task Handle(FinalizeCaseRequested message, IMessageHandlerContext context)
        {
            // Simulate finalization logic (e.g., finalize case in dataverse)
            await FinalizeCaseAsync(message.CaseId, message.CorrelationId, message.DocId, context);

            // Publish FinalizeCaseCompleted event
            var finalizeCaseCompletedEvent = new FinalizeCaseCompleted
            {
                CorrelationId = message.CorrelationId,
                CaseId = message.CaseId,
                PatientId = message.PatientId,
                ClinicId = message.ClinicId,
                CreatedAt = DateTimeOffset.UtcNow,
                DocId = message.DocId
            };

            await context.Publish(finalizeCaseCompletedEvent);
        }

        private static async Task FinalizeCaseAsync(string caseId, string correlationId, string docId, IMessageHandlerContext context)
        {
            var session = context.SynchronizedStorageSession.CosmosPersistenceSession();
            var finalizeHealthCaseRequest = await session.Container.ReadItemAsync<Medical.Domain.Managers.Services.CosmosService.RegisterMedicalExaminationsResultsRequest>(docId, new PartitionKey(correlationId), cancellationToken: context.CancellationToken);
            finalizeHealthCaseRequest.Resource.IsProcessed = "1"; // Mark as finalized
            finalizeHealthCaseRequest.Resource.CaseId = caseId;
            session.Batch.ReplaceItem(docId, finalizeHealthCaseRequest.Resource);
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using NServiceBus;

using Medical.Domain.Contracts.Events;
using Medical.Domain.Managers.Services.CosmosService;

namespace Endpoint.In.Handlers
{
    public class CaseUpdateRequestedHandler : IHandleMessages<CaseUpdateRequested>
    {
        public async Task Handle(CaseUpdateRequested message, IMessageHandlerContext context)
        {
            // Simulate update logic (e.g., update case in dataverse)
            await UpdateCaseAsync(message.CaseId, message.CorrelationId, message.DocId, context);

            // Publish CaseUpdateCompleted event
            var caseUpdateCompletedEvent = new CaseUpdateCompleted
            {
                CorrelationId = message.CorrelationId,
                CaseId = message.CaseId,
                PatientId = message.PatientId,
                ClinicId = message.ClinicId,
                CreatedAt = DateTimeOffset.UtcNow,
                DocId = message.DocId
            };

            await context.Publish(caseUpdateCompletedEvent);
        }

        private static async Task UpdateCaseAsync(string caseId, string correlationId, string docId, IMessageHandlerContext context)
        {
            var session = context.SynchronizedStorageSession.CosmosPersistenceSession();
            var updateHealthCaseRequest = await session.Container.ReadItemAsync<Medical.Domain.Managers.Services.CosmosService.NotifyMedicalExaminationStatusRequest>(docId, new PartitionKey(correlationId), cancellationToken: context.CancellationToken);
            updateHealthCaseRequest.Resource.IsProcessed = "1"; // Mark as updated
            updateHealthCaseRequest.Resource.CaseId = caseId;
            session.Batch.ReplaceItem(docId, updateHealthCaseRequest.Resource);
        }
    }
}

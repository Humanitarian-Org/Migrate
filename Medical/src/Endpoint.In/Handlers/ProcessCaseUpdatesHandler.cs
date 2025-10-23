using System.Threading.Tasks;
using NServiceBus;
using Medical.Domain.Contracts.Commands;
using Medical.Domain.Managers.Services.CosmosService;
using Medical.Domain.Contracts.Events;
namespace Endpoint.In.Handlers
{
    public class ProcessCaseUpdatesHandler : IHandleMessages<ProcessCaseUpdate>
    {
        private CosmosRepository _cosmosRepository;
        public ProcessCaseUpdatesHandler(CosmosRepository cosmosRepository)
        {
            _cosmosRepository = cosmosRepository;
        }

        public async Task Handle(ProcessCaseUpdate message, IMessageHandlerContext context)
        {
            // call cosmosdb to first check for 439 || 440 if not found, then 441
            // if found 439 || 440, send to dataverse and then publish message to markascompleted
            // if found 441, then send message to dataverse to update case and reset the timeout

            var notifyMsgCount = await _cosmosRepository.CountUnprocessedByDocTypeAsync(message.CorrelationId, "441", context.CancellationToken);
            var finalMedResultsMsgCount = await _cosmosRepository.CountUnprocessedByDocTypeAsync(message.CorrelationId, "440", context.CancellationToken);
            var deleteOrTransferMsgCount = await _cosmosRepository.CountUnprocessedByDocTypeAsync(message.CorrelationId, "439", context.CancellationToken);

            // if all the counts are zero just return
            if (notifyMsgCount == 0 && deleteOrTransferMsgCount == 0 && finalMedResultsMsgCount == 0)
            {
                // should send a mesage to the saga to check status again after some time
                await context.SendLocal(new ScheduleCaseUpdateCheck
                {
                    CorrelationId = message.CorrelationId,
                });

                //context.SendLocal
            }

            if (notifyMsgCount > 0 && deleteOrTransferMsgCount == 0 && finalMedResultsMsgCount == 0)
            {
                var healthCaseUpdateRequest = await _cosmosRepository.GetFirstUnprocessedByDocTypeAsync<Medical.Domain.Managers.Services.CosmosService.NotifyMedicalExaminationStatusRequest>(message.CorrelationId, "441", context.CancellationToken);
                if (healthCaseUpdateRequest != null)
                {
                    await context.Publish(new CaseUpdateRequested
                    {
                        CorrelationId = healthCaseUpdateRequest.CorrelationId,
                        DocId = healthCaseUpdateRequest.id,
                        CaseId = healthCaseUpdateRequest.CaseId,
                        CreatedAt = healthCaseUpdateRequest.CreatedUtc
                    });
                }
            }
            else
            {

                if (finalMedResultsMsgCount > 0) //should be only one
                {
                    var medResultsRequest = await _cosmosRepository.GetFirstUnprocessedByDocTypeAsync<Medical.Domain.Managers.Services.CosmosService.RegisterMedicalExaminationsResultsRequest>(message.CorrelationId, "440", context.CancellationToken);
                    if (medResultsRequest != null)
                    {
                        await context.Publish(new FinalizeCaseRequested
                        {
                            CorrelationId = medResultsRequest.CorrelationId,
                            DocId = medResultsRequest.id,
                            CaseId = medResultsRequest.CaseId,
                            CreatedAt = medResultsRequest.CreatedUtc
                        });
                    }
                }
                if (deleteOrTransferMsgCount > 0) //should be only one
                {
                    var deleteRequest = await _cosmosRepository.GetFirstUnprocessedByDocTypeAsync<Medical.Domain.Managers.Services.CosmosService.DeleteCachedHealthCaseRequest>(message.CorrelationId, "439", context.CancellationToken);
                    if (deleteRequest != null)
                    {
                        await context.Publish(new DeleteHealthCaseRequested
                        {
                            CorrelationId = deleteRequest.CorrelationId,
                            DocId = deleteRequest.id,
                            CaseId = deleteRequest.CaseId,
                            CreatedAt = deleteRequest.CreatedUtc
                        });

                    }
                }

            }
            //  return Task.CompletedTask;
        }

    }


}

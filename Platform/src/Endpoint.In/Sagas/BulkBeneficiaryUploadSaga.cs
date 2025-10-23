using System.Threading.Tasks;
using NServiceBus;
using Microsoft.Extensions.Logging;
using Platform.Domain.Contracts.Events;
using Platform.Domain.Contracts.Commands;
using Platform.Domain.Contracts;
using System;

namespace Endpoint.In.Sagas
{
    public class BulkBeneficiaryUploadSaga : Saga<BulkBeneficiaryUploadSagaData>,
        IAmStartedByMessages<BulkBeneficiaryUploadStarted>,
        IHandleMessages<BulkBeneficiaryParsedAndSent>,
        IHandleTimeouts<BeneficiaryProcessingStatusCheck>

    {
        private readonly ILogger<BulkBeneficiaryUploadSaga> _logger;
        private readonly Platform.Domain.Managers.IBulkBeneficiaryUploadManager _bulkBeneficiaryUploadManager;

        public BulkBeneficiaryUploadSaga(ILogger<BulkBeneficiaryUploadSaga> logger, Platform.Domain.Managers.IBulkBeneficiaryUploadManager BulkBeneficiaryUploadManager)
        {
            _logger = logger;
            _bulkBeneficiaryUploadManager = BulkBeneficiaryUploadManager;
        }

        public async Task Handle(BulkBeneficiaryUploadStarted message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[BulkBeneficiaryUploadSaga] Saga started: Upload processing initiated | CorrelationId: {message.CorrelationId} | SagaId: {Data.Id}");
            
            Data.DocId = message.DocId;
            Data.CorrelationId = message.CorrelationId;
            Data.UploadId = message.UploadId;
            Data.TotalRecordsCount = message.TotalRecordsCount;
            Data.UserId = message.UserId;
            Data.FileName = message.FileName;
            Data.StartedAt = message.StartedAt;

            _logger.LogInformation($"[BulkBeneficiaryUploadSaga] Saga data initialized | UploadId: {message.UploadId} | Records: {message.TotalRecordsCount} | StoredCorrelationId: {Data.CorrelationId}");
            
            // Publish event to start processing the bulk beneficiary upload
            await context.Publish(new BulkBeneficiarySagaStarted
            {
                CorrelationId = message.CorrelationId,
                DocId = message.DocId,
                UploadId = message.UploadId,
                TotalRecordsCount = message.TotalRecordsCount,
                UserId = message.UserId,
                FileName = message.FileName,
                StartedAt = message.StartedAt
            });

            // Start timeout mechanism to periodically check beneficiary processing progress
            await RequestTimeout<BeneficiaryProcessingStatusCheck>(context, TimeSpan.FromSeconds(3), new BeneficiaryProcessingStatusCheck
            {
                CorrelationId = message.CorrelationId,
                CheckCount = 1
            });
                _logger.LogInformation($"[BulkBeneficaryUploadSaga] Started timeout mechanism for processing status checks | CorrelationId: {message.CorrelationId}");
        
        }

        public async Task Handle(BulkBeneficiaryParsedAndSent message, IMessageHandlerContext context)
        {
            Data.ProcessedRecords = message.TotalRecordsParsed;
               await context.Publish(new BulkBeneficiaryUploadProgress
                {
                    CorrelationId = Data.CorrelationId,
                    UploadId = Data.UploadId,
                    ProcessedRecords = 0,
                    TotalRecords = Data.TotalRecordsCount,
                    SuccessfulRecords = 0,
                    FailedRecords = 0,
                    Status = $"Parsed and Sent: 0/{Data.TotalRecordsCount} (0.0%) - {Data.TotalRecordsCount} remaining",
                    UpdatedAt = DateTimeOffset.UtcNow
                });
            
        }

        public async Task Timeout(BeneficiaryProcessingStatusCheck state, IMessageHandlerContext context)
        {
            _logger.LogError($"[BulkBeneficiaryUploadSaga] Timeout triggered: Checking processing status | CorrelationId: {state.CorrelationId} | CheckCount: {state.CheckCount}");

            // Use BulkBeneficiaryUploadManager to check the current status of beneficiary processing
            var status = await _bulkBeneficiaryUploadManager.GetBulkBeneficiaryProcessingStatus(state.CorrelationId);
            
            if (status != null)
            {
                // Update saga data with latest status
                Data.ProcessedRecords = status.ProcessedRecords;
                Data.SuccessfulRecords = status.SuccessfulRecords;
                Data.FailedRecords = status.FailedRecords;
                
                // Calculate remaining records and percentage
                int remainingRecords = Data.TotalRecordsCount - status.ProcessedRecords;
                double percentComplete = Data.TotalRecordsCount > 0 
                    ? (double)status.ProcessedRecords / Data.TotalRecordsCount * 100 
                    : 0;
                
                _logger.LogInformation($"[BulkBeneficiaryUploadSaga] Processing status update | Processed: {status.ProcessedRecords}/{Data.TotalRecordsCount} | Remaining: {remainingRecords} | Success: {status.SuccessfulRecords} | Failed: {status.FailedRecords} | Percent: {percentComplete:F1}%");
                
                // Publish progress update via SignalR
                await context.Publish(new BulkBeneficiaryUploadProgress
                {
                    CorrelationId = Data.CorrelationId,
                    UploadId = Data.UploadId,
                    ProcessedRecords = status.ProcessedRecords,
                    TotalRecords = Data.TotalRecordsCount,
                    SuccessfulRecords = status.SuccessfulRecords,
                    FailedRecords = status.FailedRecords,
                    Status = $"Processing: {status.ProcessedRecords}/{Data.TotalRecordsCount} ({percentComplete:F1}%) - {remainingRecords} remaining",
                    UpdatedAt = DateTimeOffset.UtcNow
                });
                
                _logger.LogInformation($"[BulkBeneficiaryUploadSaga] Published progress update via SignalR | CorrelationId: {state.CorrelationId} | Percent: {percentComplete:F1}%");
                
                // Check if all beneficiaries have been processed (success or failure)
                if (status.IsComplete)
                {
                    _logger.LogInformation($"[BulkBeneficiaryUploadSaga] Processing complete | CorrelationId: {state.CorrelationId} | Success: {status.SuccessfulRecords} | Failed: {status.FailedRecords}");
                    
                    // All processing is complete - publish completion event and mark saga as complete
                    await context.Publish(new BulkBeneficiaryUploadCompleted
                    {
                        CorrelationId = Data.CorrelationId,
                        UploadId = Data.UploadId,
                        TotalRecords = Data.TotalRecordsCount,
                        SuccessfulRecords = status.SuccessfulRecords,
                        FailedRecords = status.FailedRecords,
                        CompletedAt = DateTimeOffset.UtcNow,
                        Status = status.FailedRecords > 0 ? "Completed with errors" : "Completed successfully",
                        UserId = Data.UserId
                    });
                    
                    _logger.LogInformation($"[BulkBeneficiaryUploadSaga] Saga completed successfully | CorrelationId: {Data.CorrelationId}");
                    MarkAsComplete();
                    return;
                }
            }
            else
            {
                _logger.LogWarning($"[BulkBeneficiaryUploadSaga] Failed to retrieve processing status | CorrelationId: {state.CorrelationId}");
            }
            
            // If not complete and haven't exceeded max checks, schedule another timeout
            const int maxChecks = 130; // Maximum number of status checks (1 hour with 2-minute intervals)
            if (state.CheckCount < maxChecks)
            {
                await RequestTimeout<BeneficiaryProcessingStatusCheck>(context, TimeSpan.FromSeconds(1), new BeneficiaryProcessingStatusCheck
                {
                    CorrelationId = state.CorrelationId,
                    CheckCount = state.CheckCount + 1
                });
                
                _logger.LogInformation($"[BulkBeneficiaryUploadSaga] Scheduled next status check | CorrelationId: {state.CorrelationId} | NextCheck: {state.CheckCount + 1}");
            }
            else
            {
                _logger.LogWarning($"[BulkBeneficiaryUploadSaga] Maximum status checks exceeded - marking as timed out | CorrelationId: {state.CorrelationId}");
                
                // Handle timeout scenario - publish timeout event
                await context.Publish(new BulkBeneficiaryUploadTimedOut
                {
                    CorrelationId = Data.CorrelationId,
                    UploadId = Data.UploadId,
                    TimedOutAt = DateTimeOffset.UtcNow,
                    UserId = Data.UserId
                });
                
                MarkAsComplete();
            }
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<BulkBeneficiaryUploadSagaData> mapper)
        {

            mapper.MapSaga(saga => saga.CorrelationId)
                .ToMessage<BulkBeneficiaryUploadStarted>(message => message.CorrelationId)
                .ToMessage<BulkBeneficiaryParsedAndSent>(message => message.CorrelationId);
          
            // TODO: Add mappings for other messages
            // mapper.MapSaga(saga => saga.CorrelationId)
            //     .ToMessage<BeneficiaryRecordProcessed>(message => message.CorrelationId);
        }

    }

    public class BulkBeneficiaryUploadSagaData : ContainSagaData, Platform.Domain.Contracts.IProvideCorrelationId
    {
        public string CorrelationId { get; set; }
        public string DocId { get; set; }
        public string UploadId { get; set; }
        public int TotalRecordsCount { get; set; }
        public string UserId { get; set; }
        public string FileName { get; set; }
        public DateTimeOffset StartedAt { get; set; }
        
        // Progress tracking properties
        public int ProcessedRecords { get; set; } = 0;
        public int SuccessfulRecords { get; set; } = 0;
        public int FailedRecords { get; set; } = 0;
    }
    
    public class BeneficiaryProcessingStatusCheck : IProvideCorrelationId
    {
        public string CorrelationId { get; set; }
        public int CheckCount { get; set; }
    }
}

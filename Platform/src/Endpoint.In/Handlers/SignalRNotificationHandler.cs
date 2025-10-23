using System.Threading.Tasks;
using NServiceBus;
using Microsoft.Extensions.Logging;
using Platform.Domain.Contracts.Events;
using Platform.Domain.Services;

namespace Endpoint.In.Handlers
{
    /// <summary>
    /// Dedicated handler for sending events to SignalR hub for real-time UI notifications.
    /// This handler processes events independently from business logic handlers/sagas.
    /// </summary>
    public class SignalRNotificationHandler : 
        IHandleMessages<BulkBeneficiaryUploadStarted>,
        IHandleMessages<BulkBeneficiaryUploadProgress>,
        IHandleMessages<BulkBeneficiaryUploadCompleted>,
        IHandleMessages<BulkBeneficiaryUploadTimedOut>
        // Add other event types here as needed:
        // IHandleMessages<BeneficiaryRecordProcessed>,
        // IHandleMessages<BeneficiaryProcessingFailed>,
        // etc.
    {
        private readonly ILogger<SignalRNotificationHandler> _logger;
        private readonly ISignalRService _signalRService;

        public SignalRNotificationHandler(
            ILogger<SignalRNotificationHandler> logger, 
            ISignalRService signalRService)
        {
            _logger = logger;
            _signalRService = signalRService;
        }

        public async Task Handle(BulkBeneficiaryUploadStarted message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[SignalRNotificationHandler] Sending upload started notification to SignalR hub | CorrelationId: {message.CorrelationId}");

            try
            {
                await _signalRService.SendUploadStartedAsync(message);
                
                _logger.LogInformation($"[SignalRNotificationHandler] Successfully sent upload started notification | CorrelationId: {message.CorrelationId}");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"[SignalRNotificationHandler] Failed to send upload started notification | CorrelationId: {message.CorrelationId}");
                
                // Don't throw - we don't want to fail message processing if SignalR fails
                // SignalR notifications are not critical to the business process
            }
        }

        public async Task Handle(BulkBeneficiaryUploadProgress message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[SignalRNotificationHandler] Sending upload progress notification to SignalR hub | CorrelationId: {message.CorrelationId}");
            
            try
            {
                await _signalRService.SendUploadProgressAsync(
                    message.CorrelationId,
                    message.UploadId,
                    message.ProcessedRecords,
                    message.TotalRecords,
                    message.SuccessfulRecords,
                    message.FailedRecords,
                    message.Status
                );
                
                _logger.LogInformation($"[SignalRNotificationHandler] Successfully sent upload progress notification | CorrelationId: {message.CorrelationId} | Progress: {message.ProcessedRecords}/{message.TotalRecords} | Success: {message.SuccessfulRecords} | Failed: {message.FailedRecords}");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"[SignalRNotificationHandler] Failed to send upload progress notification | CorrelationId: {message.CorrelationId}");
            }
        }

        public async Task Handle(BulkBeneficiaryUploadCompleted message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[SignalRNotificationHandler] Sending upload completed notification to SignalR hub | CorrelationId: {message.CorrelationId}");
            
            try
            {
                await _signalRService.SendUploadCompletedAsync(
                    message.CorrelationId,
                    message.UploadId,
                    message.TotalRecords,
                    message.SuccessfulRecords,
                    message.FailedRecords,
                    message.Status,
                    message.Errors
                );
                
                _logger.LogInformation($"[SignalRNotificationHandler] Successfully sent upload completed notification | CorrelationId: {message.CorrelationId} | Status: {message.Status}");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"[SignalRNotificationHandler] Failed to send upload completed notification | CorrelationId: {message.CorrelationId}");
            }
        }

        public async Task Handle(BulkBeneficiaryUploadTimedOut message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[SignalRNotificationHandler] Sending upload timeout notification to SignalR hub | CorrelationId: {message.CorrelationId}");
            
            try
            {
                await _signalRService.SendUploadTimedOutAsync(
                    message.CorrelationId,
                    message.UploadId,
                    message.TimedOutAt
                );
                
                _logger.LogInformation($"[SignalRNotificationHandler] Successfully sent upload timeout notification | CorrelationId: {message.CorrelationId}");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"[SignalRNotificationHandler] Failed to send upload timeout notification | CorrelationId: {message.CorrelationId}");
            }
        }

        // TODO: Add handlers for other events as they are created
        
        // Examples of other events that could be handled:
        // public async Task Handle(BeneficiaryRecordProcessed message, IMessageHandlerContext context) { ... }
        // public async Task Handle(BeneficiaryProcessingFailed message, IMessageHandlerContext context) { ... }
        // public async Task Handle(DocumentValidationCompleted message, IMessageHandlerContext context) { ... }
    }
}
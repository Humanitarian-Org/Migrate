using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NServiceBus;
using Beneficiary.Domain.Contracts.Events;
using Platform.Domain.Managers;

namespace Endpoint.In.Handlers
{
    public class BeneficiaryCreationStatusHandler : 
        IHandleMessages<BeneficiaryCreationSuccess>,
        IHandleMessages<BeneficiaryCreationFailed>
    {
        private readonly ILogger<BeneficiaryCreationStatusHandler> _logger;
        private readonly IBulkBeneficiaryUploadManager _bulkBeneficiaryUploadManager;

        public BeneficiaryCreationStatusHandler(
            ILogger<BeneficiaryCreationStatusHandler> logger,
            IBulkBeneficiaryUploadManager bulkBeneficiaryUploadManager)
        {
            _logger = logger;
            _bulkBeneficiaryUploadManager = bulkBeneficiaryUploadManager;
        }

        public async Task Handle(BeneficiaryCreationSuccess message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[BeneficiaryCreationStatusHandler] Received BeneficiaryCreationSuccess | CorrelationId: {message.CorrelationId} | RecordId: {message.RecordId} | BeneficiaryId: {message.BeneficiaryId}");

            // Use BulkBeneficiaryUploadManager to update the status of this specific beneficiary record in CosmosDB
            await _bulkBeneficiaryUploadManager.UpdateBeneficiaryStatus(message.CorrelationId, message.RecordId, "Success", message.BeneficiaryId);
            
            _logger.LogInformation($"[BeneficiaryCreationStatusHandler] Updated beneficiary creation status to Success | CorrelationId: {message.CorrelationId} | RecordId: {message.RecordId} | BeneficiaryId: {message.BeneficiaryId}");
        }

        public async Task Handle(BeneficiaryCreationFailed message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[BeneficiaryCreationStatusHandler] Received BeneficiaryCreationFailed | CorrelationId: {message.CorrelationId} | RecordId: {message.RecordId} | Error: {message.Error}");

            // Use BulkBeneficiaryUploadManager to update the status of this specific beneficiary record in CosmosDB
            await _bulkBeneficiaryUploadManager.UpdateBeneficiaryStatus(message.CorrelationId, message.RecordId, "Failed", errorMessage: message.Error);
            
            _logger.LogInformation($"[BeneficiaryCreationStatusHandler] Updated beneficiary creation status to Failed | CorrelationId: {message.CorrelationId} | RecordId: {message.RecordId} | Error: {message.Error}");
        }
    }
}
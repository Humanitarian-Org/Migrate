using System;
using System.Threading.Tasks;
using Platform.Domain.Contracts.Events;

namespace Platform.Domain.Services
{
    public interface ISignalRService
    {
        Task SendUploadStartedAsync(BulkBeneficiaryUploadStarted uploadStarted);
        Task SendUploadProgressAsync(string correlationId, string uploadId, int processedRecords, int totalRecords, int successfulRecords, int failedRecords, string status);
        Task SendUploadCompletedAsync(string correlationId, string uploadId, int totalRecords, int successfulRecords, int failedRecords, string status, string[] errors = null);
        Task SendUploadTimedOutAsync(string correlationId, string uploadId, DateTimeOffset timedOutAt);
    }
}
namespace Platform.Domain.Managers
{
#nullable enable
    using System;
    using System.Threading.Tasks;
    using Platform.Domain.Managers.Services.PlatformIntegrationDb;
    using Platform.Domain.Managers.Services.CosmosService;
    using Platform.Domain.Models;
    public interface IBulkBeneficiaryUploadManager
    {
        Task<PlatformMessage> Intake(string jsonPayload);
        Task<BulkBeneficiaryUpload> ProcessBulkBeneficiaryUpload(BulkBeneficiaryUploadRequest request);
        Task<BulkBeneficiaryUpload?> GetBulkBeneficiaryUpload(string docId, string correlationId);
        Task UpdateBeneficiaryStatus(string correlationId, string recordId, string status, string? beneficiaryId = null, string? errorMessage = null);
        Task<BulkBeneficiaryProcessingStatus?> GetBulkBeneficiaryProcessingStatus(string correlationId);
    }
}
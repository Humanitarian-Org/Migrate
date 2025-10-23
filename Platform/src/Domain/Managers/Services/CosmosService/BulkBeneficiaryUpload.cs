using System;
using Platform.Domain.Models;

namespace Platform.Domain.Managers.Services.CosmosService
{
    public class BulkBeneficiaryUpload : CosmosItem
    {
        public override string DocType => "BulkBeneficiaryUpload";

        public string UploadId { get; set; } = Guid.NewGuid().ToString();
        public string FileName { get; set; }
        public string UserId { get; set; }
        public int TotalRecordsCount { get; set; }
        public DateTimeOffset StartedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset ReceivedAt { get; set; } = DateTimeOffset.UtcNow;
        public string Status { get; set; } = "Processing";
        public BeneficiaryRecord[] Records { get; set; }
    }
}
using System;

namespace Platform.Domain.Contracts.Events
{
    public class BulkBeneficiaryUploadTimedOut : IProvideCorrelationId
    {
        public string CorrelationId { get; set; }
        public string UploadId { get; set; }
        public DateTimeOffset TimedOutAt { get; set; }
        public string UserId { get; set; }
    }
}
using System;

namespace Platform.Domain.Contracts.Events
{
    public class BulkBeneficiaryParsedAndSent : IProvideCorrelationId
    {
        public string CorrelationId { get; set; }
        public string UploadId { get; set; }
        public int TotalRecordsParsed { get; set; }
        public int CommandsSent { get; set; }
        public DateTimeOffset CompletedAt { get; set; }
        public string Status { get; set; }
    }
}
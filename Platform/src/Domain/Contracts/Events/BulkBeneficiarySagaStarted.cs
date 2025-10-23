using System;

namespace Platform.Domain.Contracts.Events
{
    public class BulkBeneficiarySagaStarted : IProvideCorrelationId
    {
        public string CorrelationId { get; set; }
        public string DocId { get; set; }
        public string UploadId { get; set; }
        public int TotalRecordsCount { get; set; }
        public string UserId { get; set; }
        public string FileName { get; set; }
        public DateTimeOffset StartedAt { get; set; }
    }
}
using System;

namespace Medical.Domain.Contracts.Events
{
    public class SomeEvent
    {
        public string CorrelationId { get; set; }
        public string CaseId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string DocId { get; set; }
    }
}
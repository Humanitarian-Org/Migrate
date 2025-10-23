using System;

namespace Medical.Domain.Contracts.Events
{
    // create a CaseRegistrationCompleted event
    public class CaseRegistrationCompleted : IProvideCorrelationId
    {
        public string CorrelationId { get; set; }
        public string CaseId { get; set; }
        public string DocId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
using System;

namespace Medical.Domain.Contracts.Events
{
    public class FinalizeCaseCompleted : IProvideCorrelationId
    {
        public string CorrelationId { get; set; }
        public string CaseId { get; set; }
        public string PatientId { get; set; }
        public string ClinicId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string DocId { get; set; }
    }
}
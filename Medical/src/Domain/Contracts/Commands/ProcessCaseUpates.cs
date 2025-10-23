using System;

namespace Medical.Domain.Contracts.Commands;

public class ProcessCaseUpdate : IProvideCorrelationId
{

    public string CorrelationId { get; set; }

    public string HealthCaseId { get; set; }
    public string PatientId { get; set; }
    public string ClinicId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string DocId { get; set; }
}

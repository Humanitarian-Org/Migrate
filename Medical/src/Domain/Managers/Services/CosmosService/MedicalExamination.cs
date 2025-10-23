using System;

namespace Medical.Domain.Managers.Services.CosmosService;

public class MedicalExamination
{
    public string ExaminationId { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public string Results { get; set; }
}
using System;
using System.Collections.Generic;

namespace Medical.Domain.Managers.Services.CosmosService;

public class CaseDetails
{
    public string CaseId { get; set; }
    public string PatientId { get; set; }
    public string PatientName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }

    public List<MedicalExamination> Examinations { get; set; } = new List<MedicalExamination>();


}

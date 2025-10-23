using System;

namespace Medical.Domain.Managers.Services.CosmosService;

public class NotifyMedicalExaminationStatusRequest : CosmosItem
{
    public override string DocType => "441";
    public string CaseId { get; set; } = default!;
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    public CaseDetails CaseDetails { get; set; }
}

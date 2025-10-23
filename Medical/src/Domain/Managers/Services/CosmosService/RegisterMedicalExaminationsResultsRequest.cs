using System;

namespace Medical.Domain.Managers.Services.CosmosService;

public class RegisterMedicalExaminationsResultsRequest : CosmosItem
{
    public override string DocType => "440";
    public string CaseId { get; set; } = default!;
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}

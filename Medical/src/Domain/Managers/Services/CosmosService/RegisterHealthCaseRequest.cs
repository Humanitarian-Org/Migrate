using System;

namespace Medical.Domain.Managers.Services.CosmosService;

// Example POCOs (keep them plain)
public class RegisterHealthCaseRequest : CosmosItem
{
    public override string DocType => "445";
    public string CaseId { get; set; } = default!;
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}

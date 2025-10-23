using System;

namespace Medical.Domain.Managers.Services.CosmosService;

public class DeleteCachedHealthCaseRequest : CosmosItem
{
    public override string DocType => "439";
    public string CaseId { get; set; } = default!;
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}

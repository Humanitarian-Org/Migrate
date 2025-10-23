using System;

namespace Medical.Domain.Managers.Services.CosmosService;

public abstract class CosmosItem
{
    public string id { get; set; } = Guid.NewGuid().ToString();  // Auto-assigned GUID
    public string CorrelationId { get; set; } = default!; // container PK path = /correlationId
    public abstract string DocType { get; }               // child classes populate it (stable discriminator)
    public string IsProcessed { get; set; } = "0";        //  populate it ("0" or "1")
}

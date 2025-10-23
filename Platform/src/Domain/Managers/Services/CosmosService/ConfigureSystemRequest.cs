using System;

namespace Platform.Domain.Managers.Services.CosmosService
{
    public class ConfigureSystemRequest : CosmosItem
    {
        public override string DocType => "ConfigureSystemRequest";

        public string SystemId { get; set; } = "unknown";
        public string ConfigurationId { get; set; } = "unknown";
        public string UserId { get; set; } = "unknown";
        public DateTimeOffset ReceivedAt { get; set; } = DateTimeOffset.UtcNow;
        public SystemDetails SystemDetails { get; set; }
    }
}
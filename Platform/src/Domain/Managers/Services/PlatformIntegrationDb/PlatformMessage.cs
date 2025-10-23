namespace Platform.Domain.Managers.Services.PlatformIntegrationDb
{
    using System;
    using System.Text.Json;

    public class PlatformMessage
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public PlatformMessageMetadata Metadata { get; set; }
        public SystemConfigurationMessage SystemConfiguration { get; set; }
    }

    public class PlatformMessageMetadata
    {
        public string MessageType { get; set; }
        public DateTime ReceivedUtc { get; set; }
        public string SourceSystem { get; set; }
        public string SystemId { get; set; }
        public string CorrelationId { get; set; }
    }

    public class SystemConfigurationMessage
    {
        public PlatformMessageMetadata Metadata { get; set; }
        public JsonElement Message { get; set; }
    }
}
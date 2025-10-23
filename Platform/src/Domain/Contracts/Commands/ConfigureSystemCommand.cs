using System;

namespace Platform.Domain.Contracts.Commands
{
    public class ConfigureSystemCommand : IProvideCorrelationId
    {
        public string CorrelationId { get; set; }

        public string SystemId { get; set; }
        public string ConfigurationId { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string DocId { get; set; }
    }
}
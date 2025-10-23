using System;

namespace Platform.Domain.Contracts.Events
{
    public class SystemConfigurationCompleted : IProvideCorrelationId
    {
        public string CorrelationId { get; set; }
        public string SystemId { get; set; }
        public string ConfigurationId { get; set; }
        public string UserId { get; set; }
        public DateTimeOffset CompletedAt { get; set; }
        public string DocId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
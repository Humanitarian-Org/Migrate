using System;

namespace Platform.Domain.Managers.Services.CosmosService
{
    public class SystemDetails
    {
        public string SystemId { get; set; }
        public string ConfigurationId { get; set; }
        public string SystemName { get; set; }
        public DateTime ConfigurationDate { get; set; }
        public string Version { get; set; }
        public string Environment { get; set; }
        public string Status { get; set; }
    }
}
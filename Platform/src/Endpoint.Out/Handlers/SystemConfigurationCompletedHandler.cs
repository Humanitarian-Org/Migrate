using Platform.Domain.Contracts.Events;
using NServiceBus;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Endpoint.Out.Handlers
{
    public class SystemConfigurationCompletedHandler : IHandleMessages<SystemConfigurationCompleted>
    {
        private readonly ILogger<SystemConfigurationCompletedHandler> _logger;

        public SystemConfigurationCompletedHandler(ILogger<SystemConfigurationCompletedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(SystemConfigurationCompleted message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"Sending system configuration ack to external gateway. SystemId: {message.SystemId}, ConfigurationId: {message.ConfigurationId}, DocId: {message.DocId}, CorrelationId: {message.CorrelationId}");
            // Add any additional logic if needed
            return Task.CompletedTask;
        }
    }
}
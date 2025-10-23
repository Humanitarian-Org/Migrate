using Medical.Domain.Contracts.Events;
using NServiceBus;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Endpoint.Out.Handlers
{
    public class CaseRegistrationCompletedHandler : IHandleMessages<CaseRegistrationCompleted>
    {
        private readonly ILogger<CaseRegistrationCompletedHandler> _logger;

        public CaseRegistrationCompletedHandler(ILogger<CaseRegistrationCompletedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CaseRegistrationCompleted message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"Sending case registration ack to eMedical gateway. CaseId: {message.CaseId}, DocId: {message.DocId}, CorrelationId: {message.CorrelationId}");
            // Add any additional logic if needed
            return Task.CompletedTask;
        }
    }
}

using Medical.Domain.Contracts.Events;
using NServiceBus;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Endpoint.Out.Handlers
{
    public class FinalizeCaseCompletedHandler : IHandleMessages<FinalizeCaseCompleted>
    {
        private readonly ILogger<FinalizeCaseCompletedHandler> _logger;

        public FinalizeCaseCompletedHandler(ILogger<FinalizeCaseCompletedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(FinalizeCaseCompleted message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"Sending finalize case ack to eMedical gateway. CaseId: {message.CaseId}, DocId: {message.DocId}, CorrelationId: {message.CorrelationId}");
            return Task.CompletedTask;
        }
    }
}

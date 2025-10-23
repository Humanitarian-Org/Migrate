using Medical.Domain.Contracts.Events;
using NServiceBus;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Endpoint.Out.Handlers
{
    public class CaseUpdateCompletedHandler : IHandleMessages<CaseUpdateCompleted>
    {
        private readonly ILogger<CaseUpdateCompletedHandler> _logger;

        public CaseUpdateCompletedHandler(ILogger<CaseUpdateCompletedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CaseUpdateCompleted message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"Sending case update ack to eMedical gateway. CaseId: {message.CaseId}, DocId: {message.DocId}, CorrelationId: {message.CorrelationId}");
            return Task.CompletedTask;
        }
    }
}

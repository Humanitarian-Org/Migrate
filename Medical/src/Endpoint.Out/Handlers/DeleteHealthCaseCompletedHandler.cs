using Medical.Domain.Contracts.Events;
using NServiceBus;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Endpoint.Out.Handlers
{
    public class DeleteHealthCaseCompletedHandler : IHandleMessages<DeleteHealthCaseCompleted>
    {
        private readonly ILogger<DeleteHealthCaseCompletedHandler> _logger;

        public DeleteHealthCaseCompletedHandler(ILogger<DeleteHealthCaseCompletedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DeleteHealthCaseCompleted message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"Sending delete health case ack to eMedical gateway. CaseId: {message.CaseId}, DocId: {message.DocId}, CorrelationId: {message.CorrelationId}");
            return Task.CompletedTask;
        }
    }
}

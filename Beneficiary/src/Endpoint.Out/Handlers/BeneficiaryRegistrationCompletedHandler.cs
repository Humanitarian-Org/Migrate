using Beneficiary.Domain.Contracts.Events;
using NServiceBus;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Endpoint.Out.Handlers
{
    public class BeneficiaryRegistrationCompletedHandler : IHandleMessages<BeneficiaryRegistrationCompleted>
    {
        private readonly ILogger<BeneficiaryRegistrationCompletedHandler> _logger;

        public BeneficiaryRegistrationCompletedHandler(ILogger<BeneficiaryRegistrationCompletedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(BeneficiaryRegistrationCompleted message, IMessageHandlerContext context)
        {
            _logger.LogInformation($"Sending beneficiary registration ack to external gateway. BeneficiaryId: {message.BeneficiaryId}, DocId: {message.DocId}, CorrelationId: {message.CorrelationId}");
            // Add any additional logic if needed
            return Task.CompletedTask;
        }
    }
}
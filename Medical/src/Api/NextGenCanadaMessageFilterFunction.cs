using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Medical.Domain.Managers;
using NServiceBus;
using Medical.Domain.Contracts.Events;
using Microsoft.Azure.Functions.Worker;

namespace Api
{
    public class NextGenCanadaMessageFilterFunction
    {
        private readonly IIntakeManager _intakeManager;
        private readonly ILogger _logger;
        private readonly IFunctionEndpoint _functionEndpoint;

        public NextGenCanadaMessageFilterFunction(IIntakeManager intakeManager, ILoggerFactory loggerFactory, IFunctionEndpoint functionEndpoint)
        {
            _intakeManager = intakeManager;
            _logger = loggerFactory.CreateLogger<NextGenCanadaMessageFilterFunction>();
            _functionEndpoint = functionEndpoint;
        }

        // [Function("NextGenCanadaMessageFilter")]
        // public async Task Run(
        //     [ServiceBusTrigger("nextgencanada-topic", "nextgencanada-subscription", Connection = "AzureWebJobsServiceBus")] string message, FunctionContext executionContext)
        // {
        //     _logger.LogInformation($"Received message: {message}");

        //     // Attempt to parse and persist a Cosmos item for known message types
        //     var cosmosItem = await _intakeManager.IntakeVTwo(message);

        //     if (cosmosItem == null)
        //     {
        //         _logger.LogInformation("No Cosmos item parsed from request body");
        //     }
        //     else if (cosmosItem is Medical.Domain.Managers.Services.CosmosService.RegisterHealthCaseRequest)
        //     {
        //         _logger.LogInformation("Parsed RegisterHealthCaseRequest from request body");

        //         await _functionEndpoint.Publish(
        //        new CaseRegistrationRequested
        //        {
        //            CorrelationId = cosmosItem.CorrelationId,
        //            DocId = cosmosItem.id,
        //        }, executionContext);
        //     }

        // }
    }
}

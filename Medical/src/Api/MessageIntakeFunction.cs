using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Medical.Domain.Managers;
using NServiceBus;
using Medical.Domain.Contracts.Events;

namespace Api
{
    public class MessageIntakeFunction
    {
        private readonly ILogger _logger;
        private readonly IIntakeManager _intakeManager;
        private readonly IFunctionEndpoint _functionEndpoint;

        public MessageIntakeFunction(ILoggerFactory loggerFactory, IIntakeManager intakeManager, IFunctionEndpoint functionEndpoint)
        {
            _logger = loggerFactory.CreateLogger<MessageIntakeFunction>();
            _intakeManager = intakeManager;
            _functionEndpoint = functionEndpoint;
        }

        [Function("MessageIntakeFunction")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestData req, FunctionContext executionContext)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            _logger.LogInformation($"Received message: {requestBody}");

            // Attempt to parse and persist a Cosmos item for known message types
            var cosmosItem = await _intakeManager.IntakeVTwo(requestBody);

            if (cosmosItem == null)
            {
                _logger.LogInformation("No Cosmos item parsed from request body");
            }
            else if (cosmosItem is Medical.Domain.Managers.Services.CosmosService.RegisterHealthCaseRequest)
            {
                _logger.LogInformation("Parsed RegisterHealthCaseRequest from request body");

                await _functionEndpoint.Publish(
               new CaseRegistrationRequested
               {
                   CorrelationId = cosmosItem.CorrelationId,
                   DocId = cosmosItem.id,
               }, executionContext);
            }


            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteStringAsync("Message processed");
            return response;

        }
    }
}
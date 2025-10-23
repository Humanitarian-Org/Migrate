using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using NServiceBus;
using Medical.Domain.Contracts.Events;

namespace Api
{
    public class ReceiveSoapMessageFunction
    {
        private readonly ILogger _logger;
        private readonly IFunctionEndpoint _functionEndpoint;

        public ReceiveSoapMessageFunction(ILoggerFactory loggerFactory, IFunctionEndpoint functionEndpoint)
        {
            _logger = loggerFactory.CreateLogger<ReceiveSoapMessageFunction>();
            _functionEndpoint = functionEndpoint;
        }

        [Function("ReceiveSoapMessage")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "soap")] HttpRequestData req, 
            FunctionContext executionContext)
        {
            _logger.LogInformation("=== ReceiveSoapMessage Function Started ===");
            
            // Log content type
            var contentType = req.Headers.TryGetValues("Content-Type", out var values) 
                ? string.Join(", ", values) 
                : "unknown";
            _logger.LogInformation("Content-Type: {ContentType}", contentType);

            // Read the raw SOAP XML from the request body
            string soapXmlString = await new StreamReader(req.Body).ReadToEndAsync();
            
            _logger.LogInformation("Received SOAP XML: {Length} bytes", soapXmlString.Length);
            _logger.LogDebug("SOAP XML preview (first 500 chars): {Preview}", 
                soapXmlString.Length > 500 ? soapXmlString.Substring(0, 500) + "..." : soapXmlString);

            // Validate that it's XML
            try
            {
                XDocument.Parse(soapXmlString);
                _logger.LogInformation("SOAP XML is valid");
            }
            catch (System.Xml.XmlException ex)
            {
                _logger.LogError(ex, "Invalid XML received");
                var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await errorResponse.WriteStringAsync("Invalid XML");
                return errorResponse;
            }

            // Create and publish the NServiceBus event with SOAP envelope as string
            var medicalMsg = new eMedicalMsgRecieved
            {
                SoapEnvelope = soapXmlString  // Store raw SOAP XML as string
            };

            _logger.LogInformation("Publishing eMedicalMsgRecieved event to NServiceBus");
            
            try
            {
                await _functionEndpoint.Publish(medicalMsg, executionContext);
                _logger.LogInformation("Successfully published eMedicalMsgRecieved event");
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Failed to publish eMedicalMsgRecieved event");
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteStringAsync("Failed to publish message");
                return errorResponse;
            }

            _logger.LogInformation("=== ReceiveSoapMessage Function Completed ===");
            
            var response = req.CreateResponse(HttpStatusCode.Accepted);
            await response.WriteStringAsync("SOAP message accepted and published to NServiceBus");
            return response;
        }
    }
}

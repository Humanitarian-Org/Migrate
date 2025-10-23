using System;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using NServiceBus;
using Medical.Domain.Contracts.Events;

namespace Api.Handlers
{
    public class eMedicalMsgRecievedHandler : IHandleMessages<eMedicalMsgRecieved>
    {
        private readonly ILogger<eMedicalMsgRecievedHandler> _logger;

        public eMedicalMsgRecievedHandler(ILogger<eMedicalMsgRecievedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(eMedicalMsgRecieved message, IMessageHandlerContext context)
        {
            try
            {
                _logger.LogInformation("=== eMedicalMsgRecieved Handler Started ===");
                
                // Log message instance status
                if (message == null)
                {
                    _logger.LogError("Message is NULL - this should never happen");
                    return Task.CompletedTask;
                }

                _logger.LogInformation("Message received - Type: {MessageType}", message.GetType().FullName);
                
                // Log all message headers for debugging
                _logger.LogInformation("=== NServiceBus Message Headers ===");
                foreach (var header in context.MessageHeaders)
                {
                    _logger.LogInformation("  {Key} = {Value}", header.Key, header.Value);
                }

                // Decode SOAP envelope - prefer Base64 for bit-perfect preservation
                string soapXml = null;
                
                if (!string.IsNullOrEmpty(message.SoapEnvelopeBase64))
                {
                    _logger.LogInformation("Decoding Base64-encoded SOAP envelope - Length: {Length} characters", 
                        message.SoapEnvelopeBase64.Length);
                    
                    try
                    {
                        var soapBytes = Convert.FromBase64String(message.SoapEnvelopeBase64);
                        soapXml = System.Text.Encoding.UTF8.GetString(soapBytes);
                        _logger.LogInformation("Successfully decoded Base64 SOAP - Result: {Length} characters", soapXml.Length);
                    }
                    catch (Exception decodeEx)
                    {
                        _logger.LogError(decodeEx, "Failed to decode Base64 SOAP envelope");
                        throw;
                    }
                }
                else if (!string.IsNullOrEmpty(message.SoapEnvelope))
                {
                    _logger.LogInformation("Using string SOAP envelope (not Base64) - Length: {Length} characters", 
                        message.SoapEnvelope.Length);
                    soapXml = message.SoapEnvelope;
                }
                else
                {
                    _logger.LogWarning("Both SoapEnvelopeBase64 and SoapEnvelope are NULL or empty");
                    _logger.LogWarning("This means the message was not properly formatted when sent to Service Bus");
                    _logger.LogWarning("Expected: NServiceBus message wrapper containing SoapEnvelopeBase64 or SoapEnvelope property");
                    return Task.CompletedTask;
                }

                // Check if SOAP envelope exists
                if (string.IsNullOrEmpty(soapXml))
                {
                    _logger.LogWarning("Failed to obtain SOAP XML from message");
                    return Task.CompletedTask;
                }
                
                // Parse the SOAP XML string to XDocument
                XDocument soapEnvelope;
                try
                {
                    soapEnvelope = XDocument.Parse(soapXml);
                    _logger.LogInformation("Successfully parsed SOAP XML - Root element: {RootElement}", 
                        soapEnvelope.Root?.Name?.LocalName ?? "NULL");
                }
                catch (Exception parseEx)
                {
                    _logger.LogError(parseEx, "Failed to parse SOAP XML. First 500 chars: {Preview}", 
                        soapXml.Length > 500 ? soapXml.Substring(0, 500) : soapXml);
                    throw;
                }
                
                // Define namespaces for XPath queries
                var ns = new XmlNamespaceManager(new NameTable());
                ns.AddNamespace("soap", "http://www.w3.org/2003/05/soap-envelope");
                ns.AddNamespace("ns3", "http://www.immi.gov.au/Namespace/Health/Service/V2.0");
                ns.AddNamespace("core", "http://www.immi.gov.au/Namespace/Health/Core/V1.0");

                // Extract CorrelationID from the SOAP body
                var correlationIdElement = soapEnvelope.XPathSelectElement(
                    "//soap:Body/ns3:RegisterHealthCaseRequest/core:CorrelationID", ns);
                
                if (correlationIdElement != null)
                {
                    _logger.LogInformation("CorrelationID extracted: {CorrelationId}", correlationIdElement.Value);
                }
                else
                {
                    _logger.LogWarning("Could not extract CorrelationID using XPath");
                }

                // Log first 1000 characters of SOAP message
                _logger.LogDebug("SOAP message preview (first 1000 chars): {Preview}", 
                    soapXml.Length > 1000 ? soapXml.Substring(0, 1000) + "..." : soapXml);

                // TODO: Process the SOAP message
                // - Deserialize specific parts as needed
                // - Store in CosmosDB
                // - Publish further events

                _logger.LogInformation("=== eMedicalMsgRecieved Handler Completed Successfully ===");
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing eMedical message");
                throw;
            }
        }
    }
}

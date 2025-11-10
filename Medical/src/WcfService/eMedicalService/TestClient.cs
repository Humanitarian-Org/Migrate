using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eMedicalServiceTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Testing eMedical Service Endpoints...");
            
            try
            {
                // Test SOAP 1.2 endpoint (default)
                await TestSoap12Endpoint();
                
                // Test SOAP 1.1 endpoint
                await TestSoap11Endpoint();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static async Task TestSoap12Endpoint()
        {
            Console.WriteLine("\\n=== Testing SOAP 1.2 Endpoint ===");
            
            var soapEnvelope = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                "<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\">" +
                   "<soap:Header>" +
                      "<wsa:Action xmlns:wsa=\"http://www.w3.org/2005/08/addressing\">http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/RegisterHealthCaseRequest</wsa:Action>" +
                   "</soap:Header>" +
                   "<soap:Body>" +
                      "<ns6:RegisterHealthCaseRequest xmlns:ns6=\"http://www.immi.gov.au/Namespace/Health/Service/V2.0\">" +
                         "<CorrelationID xmlns=\"http://www.immi.gov.au/Namespace/Health/Core/V1.0\">TEST-12345</CorrelationID>" +
                      "</ns6:RegisterHealthCaseRequest>" +
                   "</soap:Body>" +
                "</soap:Envelope>";

            using (var client = new HttpClient())
            {
                var content = new StringContent(soapEnvelope, Encoding.UTF8, "application/soap+xml");
                
                var response = await client.PostAsync("http://localhost:55766/eMedicalIntegrationServiceCorrect.svc", content);
                
                Console.WriteLine($"Status: {response.StatusCode}");
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {responseContent}");
            }
        }

        static async Task TestSoap11Endpoint()
        {
            Console.WriteLine("\\n=== Testing SOAP 1.1 Endpoint ===");
            
            var soapEnvelope = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">" +
                   "<soap:Body>" +
                      "<ns6:RegisterHealthCaseRequest xmlns:ns6=\"http://www.immi.gov.au/Namespace/Health/Service/V2.0\">" +
                         "<CorrelationID xmlns=\"http://www.immi.gov.au/Namespace/Health/Core/V1.0\">TEST-67890</CorrelationID>" +
                      "</ns6:RegisterHealthCaseRequest>" +
                   "</soap:Body>" +
                "</soap:Envelope>";

            using (var client = new HttpClient())
            {
                var content = new StringContent(soapEnvelope, Encoding.UTF8, "text/xml");
                content.Headers.Add("SOAPAction", "http://www.immi.gov.au/Namespace/HealthCaseIOM/ExtServices/Interface/V1/HealthCase_Ext_PortType_V1_0/RegisterHealthCaseRequest");
                
                var response = await client.PostAsync("http://localhost:55766/eMedicalIntegrationServiceCorrect.svc/soap11", content);
                
                Console.WriteLine($"Status: {response.StatusCode}");
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {responseContent}");
            }
        }
    }
}";
            
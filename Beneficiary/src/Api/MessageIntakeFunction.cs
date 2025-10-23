using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using Beneficiary.Domain.Managers;
using Beneficiary.Domain.DTOs;
using NServiceBus;
using Beneficiary.Domain.Contracts.Events;

namespace Api
{
    public class MessageIntakeFunction
    {
        private readonly ILogger _logger;
        private readonly IBeneficiaryManager _beneficiaryManager;
        private readonly IFunctionEndpoint _functionEndpoint;

        public MessageIntakeFunction(ILoggerFactory loggerFactory, IBeneficiaryManager beneficiaryManager, IFunctionEndpoint functionEndpoint)
        {
            _logger = loggerFactory.CreateLogger<MessageIntakeFunction>();
            _beneficiaryManager = beneficiaryManager;
            _functionEndpoint = functionEndpoint;
        }

        [Function("MessageIntakeFunction")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequestData req, FunctionContext executionContext)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            _logger.LogInformation($"[MessageIntakeFunction] Received beneficiary registration request");

            try
            {
                // Parse JSON request to BeneficiaryRegistrationDto
                var registrationDto = JsonSerializer.Deserialize<BeneficiaryRegistrationDto>(requestBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (registrationDto == null)
                {
                    _logger.LogWarning("[MessageIntakeFunction] Failed to parse request body as BeneficiaryRegistrationDto");
                    var badRequestResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                    await badRequestResponse.WriteStringAsync("Invalid request format");
                    return badRequestResponse;
                }

                // Set correlation ID if not provided
                registrationDto.CorrelationId ??= Guid.NewGuid().ToString();

                // Register the beneficiary using the domain manager
                var result = await _beneficiaryManager.RegisterBeneficiaryAsync(registrationDto);

                if (result.IsSuccess)
                {
                    _logger.LogInformation($"[MessageIntakeFunction] Successfully registered beneficiary | BeneficiaryId: {result.BeneficiaryId}");
                    
                    var successResponse = req.CreateResponse(HttpStatusCode.Created);
                    await successResponse.WriteAsJsonAsync(new 
                    { 
                        success = true,
                        beneficiaryId = result.BeneficiaryId,
                        message = "Beneficiary registered successfully" 
                    });
                    return successResponse;
                }
                else
                {
                    _logger.LogWarning($"[MessageIntakeFunction] Beneficiary registration failed | Error: {result.ErrorMessage}");
                    
                    var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                    await errorResponse.WriteAsJsonAsync(new 
                    { 
                        success = false,
                        error = result.ErrorMessage,
                        validationErrors = result.ValidationErrors
                    });
                    return errorResponse;
                }
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "[MessageIntakeFunction] Failed to parse JSON request");
                var parseErrorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await parseErrorResponse.WriteStringAsync("Invalid JSON format");
                return parseErrorResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[MessageIntakeFunction] Unexpected error processing beneficiary registration");
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                await errorResponse.WriteStringAsync("Internal server error");
                return errorResponse;
            }
        }
    }
}
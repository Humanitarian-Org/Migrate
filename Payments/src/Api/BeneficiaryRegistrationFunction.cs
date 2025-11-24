#nullable enable
using System;
using System.Linq;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;
using Beneficiary.Domain.Managers;
using Beneficiary.Domain.DTOs;

namespace Beneficiary.Api
{
    public class BeneficiaryRegistrationFunction
    {
        private readonly ILogger _logger;
        private readonly IBeneficiaryManager _beneficiaryManager;

        public BeneficiaryRegistrationFunction(ILoggerFactory loggerFactory, IBeneficiaryManager beneficiaryManager)
        {
            _logger = loggerFactory.CreateLogger<BeneficiaryRegistrationFunction>();
            _beneficiaryManager = beneficiaryManager;
        }

        [Function("RegisterBeneficiary")]
        public async Task<HttpResponseData> RegisterBeneficiary(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "beneficiary/register")] HttpRequestData req, 
            FunctionContext executionContext)
        {
            try
            {
                // Parse query string for dryRun parameter using modern QueryHelpers
                _logger.LogInformation($"DEBUG: Query string = '{req.Url.Query}'");
                
                var queryParams = QueryHelpers.ParseQuery(req.Url.Query);
                
                bool dryRun = false;
                if (queryParams.TryGetValue("dryRun", out var dryRunValue))
                {
                    bool.TryParse(dryRunValue.ToString(), out dryRun);
                }
                
                var mode = dryRun ? "DRY RUN (validation only)" : "COMMIT";

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                
                if (string.IsNullOrWhiteSpace(requestBody))
                {
                    var badRequest = req.CreateResponse(HttpStatusCode.BadRequest);
                    await badRequest.WriteStringAsync("Request body is empty");
                    return badRequest;
                }

                // Deserialize the request
                var registrationRequest = JsonSerializer.Deserialize<BeneficiaryRegistrationRequest>(requestBody, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (registrationRequest == null)
                {
                    var badRequest = req.CreateResponse(HttpStatusCode.BadRequest);
                    await badRequest.WriteStringAsync("Invalid request format");
                    return badRequest;
                }

                _logger.LogInformation($"Processing registration for {registrationRequest.FirstName} {registrationRequest.LastName} | DryRun: {dryRun}");

                // Map request to DTO (similar to CreateBeneficiaryCommandHandler)
                var registrationDto = MapRequestToDto(registrationRequest);
                
                // Call the domain manager directly (synchronous flow) with dryRun flag
                var result = await _beneficiaryManager.RegisterBeneficiaryAsync(registrationDto, dryRun);
                
                if (result.IsSuccess)
                {
                    if (dryRun)
                    {
                        _logger.LogInformation($"Dry run validation successful - record NOT saved | RecordId: {registrationDto.RecordId}");
                    }
                    else
                    {
                        _logger.LogInformation($"Successfully registered beneficiary | BeneficiaryId: {result.BeneficiaryId}");
                    }

                    // Return success response
                    var response = req.CreateResponse(HttpStatusCode.OK);
                    response.Headers.Add("Content-Type", "application/json");
                    
                    var successMessage = dryRun 
                        ? "Validation successful - record NOT saved (dry run mode)" 
                        : "Beneficiary registered successfully";
                    
                    var successResponse = new BeneficiaryRegistrationResponse
                    {
                        IsSuccess = true,
                        BeneficiaryId = result.BeneficiaryId,
                        Message = successMessage,
                        DryRun = dryRun
                    };
                    
                    var jsonString = JsonSerializer.Serialize(successResponse, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    await response.WriteStringAsync(jsonString);

                    return response;
                }
                else
                {
                    // Handle validation or business rule failures
                    var errorMessage = result.ErrorMessage ?? "Unknown registration error";
                    if (result.ValidationErrors.Any())
                    {
                        errorMessage = string.Join("; ", result.ValidationErrors);
                    }
                    
                    _logger.LogWarning($"Beneficiary registration failed | Error: {errorMessage}");

                    // Return validation error (400 Bad Request)
                    var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                    errorResponse.Headers.Add("Content-Type", "application/json");
                    
                    var failureResponse = new BeneficiaryRegistrationResponse
                    {
                        IsSuccess = false,
                        ErrorMessage = errorMessage,
                        ValidationErrors = result.ValidationErrors.ToList(),
                        Message = "Registration failed due to validation errors"
                    };
                    
                    var jsonString = JsonSerializer.Serialize(failureResponse, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });
                    await errorResponse.WriteStringAsync(jsonString);

                    return errorResponse;
                }
            }
            catch (JsonException ex)
            {
                _logger.LogError(ex, "Invalid JSON in request body");
                var badRequest = req.CreateResponse(HttpStatusCode.BadRequest);
                await badRequest.WriteStringAsync("Invalid JSON format");
                return badRequest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing beneficiary registration");
                
                // Return technical error (500 Internal Server Error)
                var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
                errorResponse.Headers.Add("Content-Type", "application/json");
                
                var failureResponse = new BeneficiaryRegistrationResponse
                {
                    IsSuccess = false,
                    ErrorMessage = $"Technical error: {ex.Message}",
                    Message = "Registration failed due to a technical error. Please try again."
                };
                
                var jsonString = JsonSerializer.Serialize(failureResponse, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                await errorResponse.WriteStringAsync(jsonString);
                
                return errorResponse;
            }
        }

        /// <summary>
        /// Maps BeneficiaryRegistrationRequest to BeneficiaryRegistrationDto 
        /// (similar to CreateBeneficiaryCommandHandler mapping)
        /// </summary>
        private static BeneficiaryRegistrationDto MapRequestToDto(BeneficiaryRegistrationRequest request)
        {
            return new BeneficiaryRegistrationDto
            {
                RecordId = request.RecordId ?? Guid.NewGuid().ToString(),
                CorrelationId = request.CorrelationId,
                UploadId = request.UploadId,
                FirstName = request.FirstName ?? string.Empty,
                LastName = request.LastName ?? string.Empty,
                DateOfBirth = request.DateOfBirth ?? string.Empty,
                Nationality = request.Nationality ?? string.Empty,
                DocumentType = request.DocumentType ?? string.Empty,
                DocumentNumber = request.DocumentNumber ?? string.Empty,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
                City = request.City,
                Country = request.Country,
                EmergencyContact = request.EmergencyContact,
                EmergencyPhone = request.EmergencyPhone,
                MedicalConditions = request.MedicalConditions,
                SpecialNeeds = request.SpecialNeeds,
                CaseStatus = request.CaseStatus ?? "PENDING",
                CaseWorker = request.CaseWorker,
                Notes = request.Notes
            };
        }
    }

    // Request/Response DTOs for the API
    public class BeneficiaryRegistrationRequest
    {
        public string? RecordId { get; set; }
        public string? CorrelationId { get; set; }
        public string? UploadId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? EmergencyContact { get; set; }
        public string? EmergencyPhone { get; set; }
        public string? MedicalConditions { get; set; }
        public string? SpecialNeeds { get; set; }
        public string? CaseStatus { get; set; }
        public string? CaseWorker { get; set; }
        public string? Notes { get; set; }
    }

    public class BeneficiaryRegistrationResponse
    {
        public bool IsSuccess { get; set; }
        public string? BeneficiaryId { get; set; }
        public string? ErrorMessage { get; set; }
        public List<string> ValidationErrors { get; set; } = new List<string>();
        public string? Message { get; set; }
        public bool DryRun { get; set; }
    }
}
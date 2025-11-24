using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NServiceBus;
using Platform.Domain.Contracts.Commands;
using Beneficiary.Domain.Contracts.Events;
using Beneficiary.Domain.Managers;
using Beneficiary.Domain.DTOs;

namespace Endpoint.In.Handlers
{
    public class CreateBeneficiaryCommandHandler : IHandleMessages<CreateBeneficiaryCommand>
    {
        private readonly ILogger<CreateBeneficiaryCommandHandler> _logger;
        private readonly IBeneficiaryManager _beneficiaryManager;

        public CreateBeneficiaryCommandHandler(
            ILogger<CreateBeneficiaryCommandHandler> logger,
            IBeneficiaryManager beneficiaryManager)
        {
            _logger = logger;
            _beneficiaryManager = beneficiaryManager;
        }

        public async Task Handle(CreateBeneficiaryCommand command, IMessageHandlerContext context)
        {
            _logger.LogInformation($"[CreateBeneficiaryCommandHandler] Processing create beneficiary command | CorrelationId: {command.CorrelationId} | Name: {command.FirstName} {command.LastName} | RecordId: {command.RecordId}");

            try
            {
                // Map command to DTO for clean separation
                var registrationDto = MapCommandToDto(command);
                
                // Call the domain manager to register the beneficiary
                var result = await _beneficiaryManager.RegisterBeneficiaryAsync(registrationDto);
                
                if (result.IsSuccess)
                {
                    _logger.LogInformation($"[CreateBeneficiaryCommandHandler] Successfully registered beneficiary | BeneficiaryId: {result.BeneficiaryId} | RecordId: {command.RecordId} | CorrelationId: {command.CorrelationId}");

                    // Publish beneficiary creation success event
                    await context.Publish(new BeneficiaryCreationSuccess
                    {
                        CorrelationId = command.CorrelationId,
                        UploadId = command.UploadId,
                        RecordId = command.RecordId,
                        BeneficiaryId = result.BeneficiaryId!,
                        FirstName = command.FirstName,
                        LastName = command.LastName,
                        CreatedAt = DateTimeOffset.UtcNow
                    });
                }
                else
                {
                    // Handle validation or business rule failures
                    var errorMessage = result.ErrorMessage ?? "Unknown registration error";
                    if (result.ValidationErrors.Any())
                    {
                        errorMessage = $"Validation errors: {string.Join(", ", result.ValidationErrors)}";
                    }
                    
                    _logger.LogWarning($"[CreateBeneficiaryCommandHandler] Beneficiary registration failed | RecordId: {command.RecordId} | Error: {errorMessage}");

                    // Publish beneficiary creation failed event
                    await context.Publish(new BeneficiaryCreationFailed
                    {
                        CorrelationId = command.CorrelationId,
                        UploadId = command.UploadId,
                        RecordId = command.RecordId,
                        FirstName = command.FirstName,
                        LastName = command.LastName,
                        Error = errorMessage,
                        FailedAt = DateTimeOffset.UtcNow,
                        IsRetryable = false // Business validation failures are typically not retryable
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[CreateBeneficiaryCommandHandler] Unexpected error processing create beneficiary command | RecordId: {command.RecordId} | CorrelationId: {command.CorrelationId} | Name: {command.FirstName} {command.LastName}");
                
                // Publish beneficiary creation failed event for technical exceptions
                await context.Publish(new BeneficiaryCreationFailed
                {
                    CorrelationId = command.CorrelationId,
                    UploadId = command.UploadId,
                    RecordId = command.RecordId,
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    Error = $"Technical error: {ex.Message}",
                    FailedAt = DateTimeOffset.UtcNow,
                    IsRetryable = IsRetryableException(ex)
                });
                
                // Re-throw technical exceptions that should be retried
                if (IsRetryableException(ex))
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Maps CreateBeneficiaryCommand to BeneficiaryRegistrationDto for clean separation
        /// </summary>
        private static BeneficiaryRegistrationDto MapCommandToDto(CreateBeneficiaryCommand command)
        {
            return new BeneficiaryRegistrationDto
            {
                RecordId = command.RecordId,
                CorrelationId = command.CorrelationId,
                UploadId = command.UploadId,
                FirstName = command.FirstName ?? string.Empty,
                LastName = command.LastName ?? string.Empty,
                DateOfBirth = command.DateOfBirth ?? string.Empty,
                Nationality = command.Nationality ?? string.Empty,
                DocumentType = command.DocumentType ?? string.Empty,
                DocumentNumber = command.DocumentNumber ?? string.Empty,
                Email = command.Email,
                Phone = command.Phone,
                Address = command.Address,
                City = command.City,
                Country = command.Country,
                EmergencyContact = command.EmergencyContact,
                EmergencyPhone = command.EmergencyPhone,
                MedicalConditions = command.MedicalConditions,
                SpecialNeeds = command.SpecialNeeds,
                CaseStatus = command.CaseStatus ?? "PENDING",
                CaseWorker = command.CaseWorker,
                Notes = command.Notes
            };
        }

        /// <summary>
        /// Determines if an exception should trigger a retry
        /// </summary>
        private static bool IsRetryableException(Exception ex)
        {
            // TODO: Implement logic to distinguish between technical and business exceptions
            // Technical exceptions (retryable):
            // - Database timeout (SqlException with timeout)
            // - Network connectivity issues (HttpRequestException, SocketException)
            // - Temporary service unavailability (503 responses)
            // - CosmosDB throttling (429 responses)
            // 
            // Business exceptions (non-retryable):
            // - Validation errors (ArgumentException, ValidationException)
            // - Duplicate records (business logic violations)
            // - Authorization failures (UnauthorizedAccessException)
            // - Data format issues (FormatException, JsonException)

            return ex switch
            {
                TaskCanceledException => true,
                TimeoutException => true,
                System.Net.Http.HttpRequestException => true,
                System.Net.Sockets.SocketException => true,
                ArgumentException => false,
                FormatException => false,
                UnauthorizedAccessException => false,
                _ => false // Default to non-retryable for safety
            };
        }
    }
}
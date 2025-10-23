namespace Medical.Domain.Managers
{
#nullable enable
    using System;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Domain.Managers.Services.MedicalIntegrationDb;
    using Domain.Managers.Services.CosmosService;
    using System.Collections.Generic;

    public class IntakeManager : IIntakeManager
    {
        private readonly IMedicalRepository _repository;
        private readonly CosmosRepository _cosmosRepository;
        private readonly ILogger<IntakeManager> _logger;

        public IntakeManager(IMedicalRepository repository, CosmosRepository cosmosRepository, ILogger<IntakeManager> logger)
        {
            _repository = repository;
            _cosmosRepository = cosmosRepository;
            _logger = logger;
        }

        public async Task<MedicalMessage> Intake(string jsonPayload)
        {
            // Save as a MedicalMessage with CaseRegistration property populated
            var jsonDoc = JsonDocument.Parse(jsonPayload);
            string? caseId = null;
            try
            {
                var root = jsonDoc.RootElement.GetProperty("RegisterHealthCaseRequest");
                var identifiers = root.GetProperty("HealthCaseIdentifierList").GetProperty("HealthCaseIdentifier");
                foreach (var identifier in identifiers.EnumerateArray())
                {
                    if (identifier.GetProperty("Type").GetString() == "IOMGID")
                    {
                        caseId = identifier.GetProperty("Value").GetString();
                        break;
                    }
                }
            }
            catch (Exception)
            {
                // handle or log error if needed
                caseId = null;
            }

            var payloadElement = JsonSerializer.Deserialize<JsonElement>(jsonPayload);

            var medicalMessage = new MedicalMessage
            {
                id = caseId,
                Metadata = new MedicalMessageMetadata
                {
                    MessageType = "445",
                    ReceivedUtc = DateTime.UtcNow,
                    SourceSystem = "API",
                    CaseId = caseId ?? "unknown",
                    CorrelationId = Guid.NewGuid().ToString()
                },
                CaseRegistration = new CaseRegistrationMessage
                {
                    Metadata = new MedicalMessageMetadata
                    {
                        MessageType = "445",
                        ReceivedUtc = DateTime.UtcNow,
                        SourceSystem = "API",
                        CaseId = caseId ?? "unknown",
                        CorrelationId = Guid.NewGuid().ToString()
                    },

                    Message = payloadElement
                }
            };

            await _repository.SaveMessageAsync(medicalMessage);

            return medicalMessage;
        }

        public async Task<CosmosItem?> IntakeVTwo(string jsonPayload)
        {
            if (string.IsNullOrWhiteSpace(jsonPayload)) return null;

            try
            {
                using var doc = JsonDocument.Parse(jsonPayload);
                var root = doc.RootElement;

                // RegisterHealthCaseRequest -> { "RegisterHealthCaseRequest": { "CorrelationId": "123" , ... } }
                if (root.TryGetProperty("RegisterHealthCaseRequest", out var regElem))
                {
                    var item = new RegisterHealthCaseRequest();

                    if (regElem.TryGetProperty("CorrelationId", out var corr))
                        item.CorrelationId = corr.GetString() ?? item.CorrelationId;

                    // Optional CaseId if present
                    if (regElem.TryGetProperty("CaseId", out var caseIdProp))
                        item.CaseId = caseIdProp.GetString() ?? item.CaseId;
                    // populate dummy case details


                    try
                    {
                        // Persist parsed item to Cosmos
                        await _cosmosRepository.UpsertAsync(item);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to upsert RegisterHealthCaseRequest to Cosmos");
                    }

                    return item;
                }

                // NotifyMedicalExaminationStatusRequest -> { "NotifyMedicalExaminationStatusRequest": { "CorrelationId": "123" , ... } }
                if (root.TryGetProperty("NotifyMedicalExaminationStatusRequest", out var notifyElem))
                {
                    var item = new NotifyMedicalExaminationStatusRequest();


                    if (notifyElem.TryGetProperty("CorrelationId", out var corr))
                        item.CorrelationId = corr.GetString() ?? item.CorrelationId;

                    if (notifyElem.TryGetProperty("CaseId", out var caseIdProp))
                        item.CaseId = caseIdProp.GetString() ?? item.CaseId;
                    // populate dummy case details
                    item.CaseDetails = new CaseDetails
                    {
                        CaseId = item.CaseId,
                        PatientId = "P12345",
                        PatientName = "John Doe",
                        DateOfBirth = new DateTime(1980, 1, 1),
                        Gender = "Male",
                        Examinations = new List<MedicalExamination>
                            {
                                new MedicalExamination
                                {
                                    ExaminationId = "E12345",
                                    Type = "Blood Test",
                                    Date = DateTime.UtcNow,
                                    Status = "Completed",
                                    Results = "Normal"
                                }
                            }
                    };

                    try
                    {
                        // Persist parsed item to Cosmos
                        await _cosmosRepository.UpsertAsync(item).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to upsert NotifyMedicalExaminationStatusRequest to Cosmos");
                    }

                    return item;
                }

                if (root.TryGetProperty("RegisterMedicalExaminationsResultsRequest", out var registerFinalElem))
                {
                    var item = new RegisterMedicalExaminationsResultsRequest();


                    if (registerFinalElem.TryGetProperty("CorrelationId", out var corr))
                        item.CorrelationId = corr.GetString() ?? item.CorrelationId;

                    if (registerFinalElem.TryGetProperty("CaseId", out var caseIdProp))
                        item.CaseId = caseIdProp.GetString() ?? item.CaseId;
                    // populate dummy case details
                    // item.CaseDetails = new CaseDetails
                    // {
                    //     CaseId = item.CaseId,
                    //     PatientId = "P12345",
                    //     PatientName = "John Doe",
                    //     DateOfBirth = new DateTime(1980, 1, 1),
                    //     Gender = "Male",
                    //     Examinations = new List<MedicalExamination>
                    //         {
                    //             new MedicalExamination
                    //             {
                    //                 ExaminationId = "E12345",
                    //                 Type = "Blood Test",
                    //                 Date = DateTime.UtcNow,
                    //                 Status = "Completed",
                    //                 Results = "Normal"
                    //             }
                    //         }
                    // };

                    try
                    {
                        // Persist parsed item to Cosmos
                        await _cosmosRepository.UpsertAsync(item).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to upsert NotifyMedicalExaminationStatusRequest to Cosmos");
                    }

                    return item;
                }


                // NotifyMedicalExaminationStatusRequest -> { "NotifyMedicalExaminationStatusRequest": { "CorrelationId": "123" , ... } }
                if (root.TryGetProperty("DeleteCachedHealthCaseRequest", out var delElem))
                {
                    var item = new DeleteCachedHealthCaseRequest();


                    if (delElem.TryGetProperty("CorrelationId", out var corr))
                        item.CorrelationId = corr.GetString() ?? item.CorrelationId;

                    if (delElem.TryGetProperty("CaseId", out var caseIdProp))
                        item.CaseId = caseIdProp.GetString() ?? item.CaseId;

                    try
                    {
                        // Persist parsed item to Cosmos
                        await _cosmosRepository.UpsertAsync(item).ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to upsert DeleteCachedHealthCaseRequest to Cosmos");
                    }

                    return item;
                }
            }
            catch (JsonException ex)
            {
                // malformed JSON - return null so caller can handle
                _logger.LogWarning(ex, "Failed to parse JSON payload in ParseToCosmosItem");
                return null;
            }
            catch (Exception ex)
            {
                // unexpected error - return null (could log)
                _logger.LogError(ex, "Unexpected error in ParseToCosmosItem");
                return null;
            }

            // Unknown message type
            return null;
        }
    }
}

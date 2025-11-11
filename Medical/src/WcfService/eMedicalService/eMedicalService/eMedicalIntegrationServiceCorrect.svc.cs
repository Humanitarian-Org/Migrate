using System;
using System.ServiceModel;
using System.Diagnostics;
using System.IO;

namespace eMedicalService
{
    /// <summary>
    /// eMedical Integration Service Implementation with detailed logging for debugging
    /// </summary>
    public class eMedicalIntegrationServiceCorrect : IeMedicalIntegrationServiceCorrect
    {
        private static readonly string LogPath = @"C:\temp\wcf_debug.log";

        /// <summary>
        /// Registers a new health case in the system
        /// </summary>
        public RegisterHealthCaseResponseMessage RegisterHealthCaseRequest(RegisterHealthCaseRequestMessage request)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] RegisterHealthCaseRequest called";
            
            try
            {
                // Log the incoming request
                LogDebugInfo($"{logEntry} - START");
                LogDebugInfo($"Request received: {request?.GetType()?.Name ?? "null"}");
                
                if (request?.Body != null)
                {
                    LogDebugInfo($"CorrelationID: {request.Body.CorrelationID ?? "null"}");
                    LogDebugInfo($"HealthCaseIdentifierMsg count: {request.Body.HealthCaseIdentifierMsg?.Length ?? 0}");
                    
                    if (request.Body.RegisterHealthCaseClientBiographicalDetails != null)
                    {
                        var bio = request.Body.RegisterHealthCaseClientBiographicalDetails;
                        LogDebugInfo($"GivenName: {bio.GivenName ?? "null"}");
                        LogDebugInfo($"FamilyName: {bio.FamilyName ?? "null"}");
                        LogDebugInfo($"SexType: {bio.SexType ?? "null"}");
                    }
                }
                
                // Create a successful response
                var response = new RegisterHealthCaseResponseMessage
                {
                    Body = new RegisterHealthCaseResponseType
                    {
                        CorrelationID = request?.Body?.CorrelationID ?? "UNKNOWN",
                        HealthCaseRegistrationId = $"HCR-{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}",
                        ProcessedDateTime = DateTime.UtcNow,
                        ResponseCode = "SUCCESS",
                        ResponseMessage = "Health case registered successfully"
                    }
                };
                
                LogDebugInfo($"Response created: {response.Body.HealthCaseRegistrationId}");
                LogDebugInfo($"{logEntry} - SUCCESS");
                
                return response;
            }
            catch (Exception ex)
            {
                LogDebugInfo($"{logEntry} - ERROR: {ex.Message}");
                LogDebugInfo($"Exception Details: {ex}");
                
                // Return error response instead of throwing
                var errorResponse = new RegisterHealthCaseResponseMessage
                {
                    Body = new RegisterHealthCaseResponseType
                    {
                        CorrelationID = request?.Body?.CorrelationID ?? "UNKNOWN",
                        HealthCaseRegistrationId = "ERROR",
                        ProcessedDateTime = DateTime.UtcNow,
                        ResponseCode = "ERROR",
                        ResponseMessage = $"Processing failed: {ex.Message}"
                    }
                };
                
                return errorResponse;
            }
        }

        /// <summary>
        /// Notifies the system of a medical examination status change
        /// </summary>
        public NotifyMedicalExaminationStatusResponseMessage NotifyMedicalExaminationStatusRequest(NotifyMedicalExaminationStatusRequestMessage request)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] NotifyMedicalExaminationStatusRequest called";
            
            try
            {
                LogDebugInfo($"{logEntry} - START");
                LogDebugInfo($"Request received: {request?.GetType()?.Name ?? "null"}");
                
                if (request?.Body != null)
                {
                    LogDebugInfo($"CorrelationID: {request.Body.CorrelationID ?? "null"}");
                    LogDebugInfo($"ExaminationStatus: {request.Body.ExaminationStatus ?? "null"}");
                    LogDebugInfo($"HealthCaseIdentifierMsg count: {request.Body.HealthCaseIdentifierMsg?.Length ?? 0}");
                }
                
                var response = new NotifyMedicalExaminationStatusResponseMessage
                {
                    Body = new NotifyMedicalExaminationStatusResponseType
                    {
                        CorrelationID = request?.Body?.CorrelationID ?? "UNKNOWN",
                        ResponseCode = "SUCCESS",
                        ResponseMessage = "Medical examination status notification processed successfully",
                        ProcessedDateTime = DateTime.UtcNow
                    }
                };
                
                LogDebugInfo($"{logEntry} - SUCCESS");
                return response;
            }
            catch (Exception ex)
            {
                LogDebugInfo($"{logEntry} - ERROR: {ex.Message}");
                
                var errorResponse = new NotifyMedicalExaminationStatusResponseMessage
                {
                    Body = new NotifyMedicalExaminationStatusResponseType
                    {
                        CorrelationID = request?.Body?.CorrelationID ?? "UNKNOWN",
                        ResponseCode = "ERROR",
                        ResponseMessage = $"Processing failed: {ex.Message}",
                        ProcessedDateTime = DateTime.UtcNow
                    }
                };
                
                return errorResponse;
            }
        }

        /// <summary>
        /// Registers medical examination results for a health case
        /// </summary>
        public RegisterMedicalExaminationsResultsResponseMessage RegisterMedicalExaminationsResultsRequest(RegisterMedicalExaminationsResultsRequestMessage request)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] RegisterMedicalExaminationsResultsRequest called";
            
            try
            {
                LogDebugInfo($"{logEntry} - START");
                LogDebugInfo($"Request received: {request?.GetType()?.Name ?? "null"}");
                
                if (request?.Body != null)
                {
                    LogDebugInfo($"CorrelationID: {request.Body.CorrelationID ?? "null"}");
                    LogDebugInfo($"HealthCaseIdentifierMsg count: {request.Body.HealthCaseIdentifierMsg?.Length ?? 0}");
                    
                    if (request.Body.RegisterMedicalExaminationsResultsRequestIdentityDocument != null)
                    {
                        var doc = request.Body.RegisterMedicalExaminationsResultsRequestIdentityDocument;
                        LogDebugInfo($"DocumentTypeCode: {doc.DocumentTypeCode ?? "null"}");
                        LogDebugInfo($"DocumentNumber: {doc.DocumentNumber ?? "null"}");
                        LogDebugInfo($"IssuingCountryName: {doc.IssuingCountryName ?? "null"}");
                    }
                    
                    LogDebugInfo($"HealthCaseAttachmentMsg count: {request.Body.HealthCaseAttachmentMsg?.Length ?? 0}");
                }
                
                var response = new RegisterMedicalExaminationsResultsResponseMessage
                {
                    Body = new RegisterMedicalExaminationsResultsResponseType
                    {
                        CorrelationID = request?.Body?.CorrelationID ?? "UNKNOWN",
                        ResultsRegistrationId = $"MER-{Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()}",
                        ResponseCode = "SUCCESS",
                        ResponseMessage = "Medical examination results registered successfully",
                        ProcessedDateTime = DateTime.UtcNow
                    }
                };
                
                LogDebugInfo($"Response created: {response.Body.ResultsRegistrationId}");
                LogDebugInfo($"{logEntry} - SUCCESS");
                
                return response;
            }
            catch (Exception ex)
            {
                LogDebugInfo($"{logEntry} - ERROR: {ex.Message}");
                
                var errorResponse = new RegisterMedicalExaminationsResultsResponseMessage
                {
                    Body = new RegisterMedicalExaminationsResultsResponseType
                    {
                        CorrelationID = request?.Body?.CorrelationID ?? "UNKNOWN",
                        ResultsRegistrationId = "ERROR",
                        ResponseCode = "ERROR",
                        ResponseMessage = $"Processing failed: {ex.Message}",
                        ProcessedDateTime = DateTime.UtcNow
                    }
                };
                
                return errorResponse;
            }
        }

        /// <summary>
        /// Deletes a cached health case from the system
        /// </summary>
        public DeleteCachedHealthCaseResponseMessage DeleteCachedHealthCaseRequest(DeleteCachedHealthCaseRequestMessage request)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] DeleteCachedHealthCaseRequest called";
            
            try
            {
                LogDebugInfo($"{logEntry} - START");
                LogDebugInfo($"Request received: {request?.GetType()?.Name ?? "null"}");
                
                if (request?.Body != null)
                {
                    LogDebugInfo($"CorrelationID: {request.Body.CorrelationID ?? "null"}");
                    LogDebugInfo($"DeletionReason: {request.Body.DeletionReason ?? "null"}");
                    LogDebugInfo($"HealthCaseIdentifierMsg count: {request.Body.HealthCaseIdentifierMsg?.Length ?? 0}");
                }
                
                var response = new DeleteCachedHealthCaseResponseMessage
                {
                    Body = new DeleteCachedHealthCaseResponseType
                    {
                        CorrelationID = request?.Body?.CorrelationID ?? "UNKNOWN",
                        ResponseCode = "SUCCESS",
                        ResponseMessage = "Cached health case deleted successfully",
                        ProcessedDateTime = DateTime.UtcNow
                    }
                };
                
                LogDebugInfo($"{logEntry} - SUCCESS");
                return response;
            }
            catch (Exception ex)
            {
                LogDebugInfo($"{logEntry} - ERROR: {ex.Message}");
                
                var errorResponse = new DeleteCachedHealthCaseResponseMessage
                {
                    Body = new DeleteCachedHealthCaseResponseType
                    {
                        CorrelationID = request?.Body?.CorrelationID ?? "UNKNOWN",
                        ResponseCode = "ERROR",
                        ResponseMessage = $"Processing failed: {ex.Message}",
                        ProcessedDateTime = DateTime.UtcNow
                    }
                };
                
                return errorResponse;
            }
        }

        /// <summary>
        /// Notifies cached health client details update
        /// </summary>
        public AcknowledgementResponseMessage NotifyCachedHealthClientDetailsUpdateResponse(NotifyCachedHealthClientDetailsUpdateRequestMessage request)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] NotifyCachedHealthClientDetailsUpdateResponse called";
            
            try
            {
                LogDebugInfo($"{logEntry} - START");
                LogDebugInfo($"Request received: {request?.GetType()?.Name ?? "null"}");
                
                if (request?.Body != null)
                {
                    LogDebugInfo($"CorrelationID: {request.Body.CorrelationID ?? "null"}");
                    LogDebugInfo($"HealthCaseIdentifierMsg count: {request.Body.HealthCaseIdentifierMsg?.Length ?? 0}");
                }
                
                var response = new AcknowledgementResponseMessage
                {
                    Body = new AcknowledgementMessageType
                    {
                        CorrelationID = request?.Body?.CorrelationID ?? "UNKNOWN",
                        AcknowledgementCode = "SUCCESS",
                        AcknowledgementText = "Health client details update notification processed successfully",
                        ProcessedDateTime = DateTime.UtcNow
                    }
                };
                
                LogDebugInfo($"{logEntry} - SUCCESS");
                return response;
            }
            catch (Exception ex)
            {
                LogDebugInfo($"{logEntry} - ERROR: {ex.Message}");
                
                var errorResponse = new AcknowledgementResponseMessage
                {
                    Body = new AcknowledgementMessageType
                    {
                        CorrelationID = request?.Body?.CorrelationID ?? "UNKNOWN",
                        AcknowledgementCode = "ERROR",
                        AcknowledgementText = $"Processing failed: {ex.Message}",
                        ProcessedDateTime = DateTime.UtcNow
                    }
                };
                
                return errorResponse;
            }
        }

        private static void LogDebugInfo(string message)
        {
            try
            {
                // Ensure directory exists
                var directory = Path.GetDirectoryName(LogPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Write to both file and trace
                File.AppendAllText(LogPath, $"{message}\n");
                Trace.WriteLine(message);
                System.Diagnostics.Debug.WriteLine(message);
                
                // Also try to write to event log (may fail if no permissions)
                try
                {
                    using (var eventLog = new EventLog("Application"))
                    {
                        eventLog.Source = "eMedicalService";
                        eventLog.WriteEntry(message, EventLogEntryType.Information);
                    }
                }
                catch 
                {
                    // Ignore event log failures
                }
            }
            catch
            {
                // If logging fails, don't crash the service
            }
        }
    }
}
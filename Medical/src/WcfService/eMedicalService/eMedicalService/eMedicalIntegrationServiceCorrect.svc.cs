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
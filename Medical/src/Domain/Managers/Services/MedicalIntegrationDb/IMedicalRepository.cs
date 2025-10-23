namespace Medical.Domain.Managers.Services.MedicalIntegrationDb
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public interface IMedicalRepository
    {
        Task SaveMessageAsync(MedicalMessage message);
        Task<MedicalMessage> GetCaseRegistrationMeetingAsync(string id);
        Task<FinalResultsMessage> GetFinalResultsAsync(string id);
        Task<List<UpdateMessages>> GetUpdateMessagesAsync(string caseId);
        Task<DeleteOrTransferMessage> GetDeleteOrTransferAsync(string id);
    }
}

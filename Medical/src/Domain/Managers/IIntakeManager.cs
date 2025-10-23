namespace Medical.Domain.Managers
{
#nullable enable
    using System.Threading.Tasks;
    using Domain.Managers.Services.MedicalIntegrationDb;
    public interface IIntakeManager
    {
        Task<MedicalMessage> Intake(string jsonPayload);
        Task<Services.CosmosService.CosmosItem?> IntakeVTwo(string jsonPayload);
    }
}

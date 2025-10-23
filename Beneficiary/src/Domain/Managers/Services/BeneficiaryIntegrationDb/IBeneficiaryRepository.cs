namespace Beneficiary.Domain.Managers.Services.BeneficiaryIntegrationDb
{
    using System.Threading.Tasks;

    public interface IBeneficiaryRepository
    {
        Task SaveMessageAsync(BeneficiaryMessage message);
        Task<BeneficiaryMessage> GetMessageAsync(string id);
    }
}
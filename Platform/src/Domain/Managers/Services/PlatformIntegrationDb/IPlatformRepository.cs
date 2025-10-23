namespace Platform.Domain.Managers.Services.PlatformIntegrationDb
{
    using System.Threading.Tasks;

    public interface IPlatformRepository
    {
        Task SaveMessageAsync(PlatformMessage message);
        Task<PlatformMessage> GetMessageAsync(string id);
    }
}
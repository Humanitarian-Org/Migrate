using Platform.Domain.Managers.Services.PlatformIntegrationDb;

namespace Infrastructure
{
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Extensions.Logging;

    public class PlatformRepository : IPlatformRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;
        private readonly ILogger<PlatformRepository> _logger;

        public PlatformRepository(CosmosClient cosmosClient, ILogger<PlatformRepository> logger)
        {
            _cosmosClient = cosmosClient;
            _logger = logger;
            _container = _cosmosClient.GetContainer("PlatformIntegrationDB", "PlatformMessagev1");
        }

        public async Task SaveMessageAsync(PlatformMessage message)
        {
            try
            {
                await _container.UpsertItemAsync(message, new PartitionKey(message.Metadata.CorrelationId));
                _logger.LogInformation("Successfully saved platform message with ID: {MessageId}", message.id);
            }
            catch (CosmosException ex)
            {
                _logger.LogError(ex, "Failed to save platform message with ID: {MessageId}", message.id);
                throw;
            }
        }

        public async Task<PlatformMessage> GetMessageAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<PlatformMessage>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                _logger.LogWarning("Platform message with ID: {MessageId} not found", id);
                return null;
            }
            catch (CosmosException ex)
            {
                _logger.LogError(ex, "Failed to retrieve platform message with ID: {MessageId}", id);
                throw;
            }
        }
    }
}
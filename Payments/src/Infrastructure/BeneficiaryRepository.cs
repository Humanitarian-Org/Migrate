using Beneficiary.Domain.Managers.Services.BeneficiaryIntegrationDb;

namespace Infrastructure
{
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Extensions.Logging;

    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;
        private readonly ILogger<BeneficiaryRepository> _logger;

        public BeneficiaryRepository(CosmosClient cosmosClient, ILogger<BeneficiaryRepository> logger)
        {
            _cosmosClient = cosmosClient;
            _logger = logger;
            _container = _cosmosClient.GetContainer("BeneficiaryIntegrationDB", "BeneficiaryMessagev1");
        }

        public async Task SaveMessageAsync(BeneficiaryMessage message)
        {
            try
            {
                await _container.UpsertItemAsync(message, new PartitionKey(message.Metadata.CorrelationId));
                _logger.LogInformation("Successfully saved beneficiary message with ID: {MessageId}", message.id);
            }
            catch (CosmosException ex)
            {
                _logger.LogError(ex, "Failed to save beneficiary message with ID: {MessageId}", message.id);
                throw;
            }
        }

        public async Task<BeneficiaryMessage> GetMessageAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<BeneficiaryMessage>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                _logger.LogWarning("Beneficiary message with ID: {MessageId} not found", id);
                return null;
            }
            catch (CosmosException ex)
            {
                _logger.LogError(ex, "Failed to retrieve beneficiary message with ID: {MessageId}", id);
                throw;
            }
        }
    }
}
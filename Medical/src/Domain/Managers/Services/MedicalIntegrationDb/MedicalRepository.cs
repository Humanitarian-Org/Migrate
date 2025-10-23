using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace Medical.Domain.Managers.Services.MedicalIntegrationDb
{
    public class MedicalRepository : IMedicalRepository
    {
        private readonly Container _container;
        private readonly ILogger<MedicalRepository> _logger;

        public MedicalRepository(CosmosClient cosmosClient, ILogger<MedicalRepository> logger)
        {
            _container = cosmosClient.GetContainer("MedicalIntegrationDB", "MedicalMessage");
            _logger = logger;
        }

        public async Task SaveMessageAsync(MedicalMessage message)
        {
            _logger.LogInformation("Saving message: {MessageJson}", System.Text.Json.JsonSerializer.Serialize(message));
            try
            {
                await _container.UpsertItemAsync(message, new PartitionKey(message.Metadata.CaseId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error upserting item to CosmosDB");
                throw;
            }
        }

        public async Task<MedicalMessage> GetCaseRegistrationMeetingAsync(string id)
        {
            var response = await _container.ReadItemAsync<MedicalMessage>(id, new PartitionKey(id));
            return response.Resource;
        }

        public async Task<FinalResultsMessage> GetFinalResultsAsync(string id)
        {
            var response = await _container.ReadItemAsync<FinalResultsMessage>(id, new PartitionKey(id));
            return response.Resource;
        }

        public async Task<List<UpdateMessages>> GetUpdateMessagesAsync(string caseId)
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.Metadata.CaseId = @caseId AND c.Metadata.MessageType = '441'")
                .WithParameter("@caseId", caseId);
            var iterator = _container.GetItemQueryIterator<UpdateMessages>(query);
            var results = new List<UpdateMessages>();
            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

        public async Task<DeleteOrTransferMessage> GetDeleteOrTransferAsync(string id)
        {
            var response = await _container.ReadItemAsync<DeleteOrTransferMessage>(id, new PartitionKey(id));
            return response.Resource;
        }
    }
}

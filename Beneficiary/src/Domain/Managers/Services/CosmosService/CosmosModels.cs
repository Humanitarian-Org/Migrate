namespace Beneficiary.Domain.Managers.Services.CosmosService
{
    using System;
    using System.Threading.Tasks;

    public abstract class CosmosItem
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string PartitionKey { get; set; } = "beneficiary";
        public string MessageType { get; set; }
        public DateTimeOffset ReceivedAt { get; set; } = DateTimeOffset.UtcNow;
        public string CorrelationId { get; set; } = Guid.NewGuid().ToString();
    }

    public class RegisterBeneficiaryRequest : CosmosItem
    {
        public RegisterBeneficiaryRequest()
        {
            MessageType = "RegisterBeneficiaryRequest";
        }

        public string BeneficiaryId { get; set; } = "unknown";
        public string PersonId { get; set; } = "unknown";
        public string OfficeId { get; set; } = "unknown";
        public string IsProcessed { get; set; } = "0";
        public BeneficiaryDetails BeneficiaryDetails { get; set; }
    }

    public class BeneficiaryDetails
    {
        public string BeneficiaryId { get; set; }
        public string PersonId { get; set; }
        public string PersonName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Status { get; set; }
    }

    public class CosmosRepository
    {
        public async Task UpsertAsync(CosmosItem item)
        {
            // Implementation will be in Infrastructure layer
            await Task.CompletedTask;
        }
    }
}
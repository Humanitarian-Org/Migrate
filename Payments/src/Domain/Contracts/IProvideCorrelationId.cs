namespace Beneficiary.Domain.Contracts
{
    public interface IProvideCorrelationId
    {
        string CorrelationId { get; }
    }
}
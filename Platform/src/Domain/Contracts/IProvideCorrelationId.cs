namespace Platform.Domain.Contracts;
public interface IProvideCorrelationId
{
    string CorrelationId { get; }
}
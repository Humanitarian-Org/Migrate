namespace Medical.Domain.Contracts.Commands;

public class ScheduleCaseUpdateCheck : IProvideCorrelationId
{
    public string CorrelationId { get; set; }
}
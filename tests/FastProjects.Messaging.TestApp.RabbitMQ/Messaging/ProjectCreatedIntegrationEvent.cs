namespace FastProjects.Messaging.TestApp.RabbitMQ.Messaging;

public sealed record ProjectCreatedIntegrationEvent
    : IIntegrationEvent
{
    public Guid EventId { get; init; }
    public DateTime OccurredOn { get; init; }
    
    public int ProjectId { get; init; }
    public string ProjectName { get; init; }
}

using MassTransit;

namespace FastProjects.Messaging.TestApp.RabbitMQ.Messaging;

public class ProjectCreatedIntegrationEventConsumer(
    ILogger<ProjectCreatedIntegrationEventConsumer> logger) : IIntegrationEventConsumer<ProjectCreatedIntegrationEvent>
{
    public Task Consume(ConsumeContext<ProjectCreatedIntegrationEvent> context)
    {
        ArgumentNullException.ThrowIfNull(context, nameof(context));
        ArgumentNullException.ThrowIfNull(context.Message, nameof(context.Message));

        ProjectCreatedIntegrationEvent message = context.Message;
        logger.LogInformation("Received project created event: {ProjectId} - {ProjectName}", message.ProjectId, message.ProjectName);
        
        return Task.CompletedTask;
    }
}

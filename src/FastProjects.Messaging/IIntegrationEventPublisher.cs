namespace FastProjects.Messaging;

/// <summary>
/// Defines a publisher for integration events.
/// </summary>
public interface IIntegrationEventPublisher
{
    /// <summary>
    /// Publishes an integration event asynchronously.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">The type of the integration event.</typeparam>
    /// <param name="message">The integration event message to publish.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous publish operation.</returns>
    Task PublishAsync<TIntegrationEvent>(
        TIntegrationEvent message,
        CancellationToken cancellationToken = default)
        where TIntegrationEvent : class, IIntegrationEvent;
}

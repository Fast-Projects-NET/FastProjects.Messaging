using MassTransit;

namespace FastProjects.Messaging;

/// <summary>
/// Publishes integration events using MassTransit.
/// </summary>
public sealed class MassTransitMessagePublisher : IIntegrationEventPublisher
{
    private readonly IBus _bus;

    /// <summary>
    /// Initializes a new instance of the <see cref="MassTransitMessagePublisher"/> class.
    /// </summary>
    /// <param name="bus">The publish endpoint used to send messages.</param>
    public MassTransitMessagePublisher(IBus bus)
    {
        _bus = bus;
    }

    /// <summary>
    /// Publishes an integration event asynchronously.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">The type of the integration event.</typeparam>
    /// <param name="message">The integration event message to publish.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous publish operation.</returns>
    public async Task PublishAsync<TIntegrationEvent>(TIntegrationEvent message, CancellationToken cancellationToken = default)
        where TIntegrationEvent : class, IIntegrationEvent
    {
        ArgumentNullException.ThrowIfNull(message, nameof(message));
        await _bus.Publish(message, cancellationToken);
    }
}

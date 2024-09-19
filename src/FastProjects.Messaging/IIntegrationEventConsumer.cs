using MassTransit;

namespace FastProjects.Messaging;

/// <summary>
/// Defines a consumer for integration events.
/// </summary>
/// <typeparam name="TIntegrationEvent">The type of the integration event inherited from <see cref="IIntegrationEvent"/>>.</typeparam>
public interface IIntegrationEventConsumer<in TIntegrationEvent>
    : IConsumer<TIntegrationEvent>
    where TIntegrationEvent : class, IIntegrationEvent
{
}

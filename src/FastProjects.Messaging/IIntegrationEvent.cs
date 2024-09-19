namespace FastProjects.Messaging;

/// <summary>
/// Represents an integration event
/// </summary>
public interface IIntegrationEvent
{
    /// <summary>
    /// The unique identifier for the event.
    /// </summary>
    Guid EventId { get; }

    /// <summary>
    /// The date and time when the event occurred.
    /// </summary>
    DateTime OccurredOn { get; }
}

using FluentAssertions;
using MassTransit;
using NSubstitute;

namespace FastProjects.Messaging.UnitTests;

public class MassTransitMessagePublisherTests
{
    [Fact]
    public void PublishAsync_Should_ThrowArgumentNullException_WhenMessageIsNull()
    {
        // Arrange
        IBus? bus = Substitute.For<IBus>();
        var publisher = new MassTransitMessagePublisher(bus);

        // Act
        Func<Task> act = async () => await publisher.PublishAsync<IIntegrationEvent>(null!);

        // Assert
        act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task PublishAsync_Should_PublishMessage_WhenMessageIsNotNull()
    {
        // Arrange
        IBus? bus = Substitute.For<IBus>();
        var publisher = new MassTransitMessagePublisher(bus);
        var message = new TestIntegrationEvent();

        // Act
        await publisher.PublishAsync(message);

        // Assert
        await bus.Received(1).Publish(message, Arg.Any<CancellationToken>());
    }
    
    private class TestIntegrationEvent : IIntegrationEvent
    {
        public Guid EventId { get; } = Guid.NewGuid();
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }
}

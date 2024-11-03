namespace RecurrenceHub.Domain.Users.Events;

public record SubscriptionCanceledEvent(Guid subscriptionId) : IDomainEvent;
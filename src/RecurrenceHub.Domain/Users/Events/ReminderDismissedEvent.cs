namespace RecurrenceHub.Domain.Users.Events;

public record ReminderDismissedEvent(Guid ReminderId) : IDomainEvent;
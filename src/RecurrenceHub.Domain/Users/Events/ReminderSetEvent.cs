using RecurrenceHub.Domain.Reminders;

namespace RecurrenceHub.Domain.Users.Events;

public record ReminderSetEvent(Reminder Reminder) : IDomainEvent;
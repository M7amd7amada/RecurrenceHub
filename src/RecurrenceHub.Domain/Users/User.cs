using ErrorOr;

using RecurrenceHub.Domain.Reminders;
using RecurrenceHub.Domain.Users.Events;

using Throw;

namespace RecurrenceHub.Domain.Users;

public class User : Entity
{
    private readonly Calender _calender = null!;
    private readonly ICollection<Guid> _remindersIds = [];
    private readonly ICollection<Guid> _dismissedRemindersIds = [];

    public Subscription Subscription { get; private set; } = null!;
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    public string Email { get; } = default!;

    public User(
        Guid id,
        string firstName,
        string lastName,
        string email,
        Calender? calender = null) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        _calender = calender ?? Calender.Empty();
    }

    public ErrorOr<Success> SetReminder(Reminder reminder)
    {
        if (Subscription == Subscription.Canceled)
        {
            return Error.NotFound(description: "Subscription not found.");
        }

        reminder.ThrowIfNull();
        reminder.SubscriptionId.Throw().IfNotEquals(Subscription.Id);

        if (HasReachedDailyReminderLimit(reminder.DateTime))
        {
            return UserErrors.CannotCreateMoreRemindersThanSubscriptionAllows;
        }

        _calender.IncrementEventCount(reminder.Date);

        _remindersIds.Add(reminder.Id);

        _domainEvents.Add(new ReminderSetEvent(reminder));

        return Result.Success;
    }

    public ErrorOr<Success> DismissReminder(Guid reminderId)
    {
        if (Subscription == Subscription.Canceled)
        {
            return Error.NotFound(description: "Subscription not found.");
        }

        if (!_remindersIds.Contains(reminderId))
        {
            return Error.NotFound(description: "Reminder not found.");
        }

        if (_dismissedRemindersIds.Contains(reminderId))
        {
            return Error.Conflict(description: "Reminder already dismissed.");
        }

        _dismissedRemindersIds.Add(reminderId);

        _domainEvents.Add(new ReminderDismissedEvent(reminderId));

        return Result.Success;
    }

    public ErrorOr<Success> CancelSubscription(Guid subscriptionId)
    {
        if (subscriptionId != Subscription.Id)
        {
            return Error.NotFound(description: "Subscription not found.");
        }

        Subscription = Subscription.Canceled;

        _domainEvents.Add(new SubscriptionCanceledEvent(subscriptionId));

        return Result.Success;
    }

    public ErrorOr<Success> DeleteReminder(Reminder reminder)
    {
        if (Subscription == Subscription.Canceled)
        {
            return Error.NotFound(description: "Subscription not found.");
        }

        reminder.ThrowIfNull();

        if (!_remindersIds.Remove(reminder.Id))
        {
            return Error.NotFound(description: "Reminder not found.");
        }

        _dismissedRemindersIds.Remove(reminder.Id);

        _calender.DecrementEventCount(reminder.Date);

        _domainEvents.Add(new ReminderDeletedEvent(reminder.Id));

        return Result.Success;
    }

    public void DeleteAllReminders()
    {
        foreach (var reminderId in _remindersIds)
        {
            _domainEvents.Add(new ReminderDeletedEvent(reminderId));
        }

        _remindersIds.Clear();
    }

    private bool HasReachedDailyReminderLimit(DateTimeOffset dateTime)
    {
        var dailyReminderCount = _calender.GetNumEventsOnDay(dateTime);

        return dailyReminderCount >= Subscription.SubscriptionType.GetMaxDailyReminders
            || dailyReminderCount == int.MinValue;
    }

    private User() { }
}
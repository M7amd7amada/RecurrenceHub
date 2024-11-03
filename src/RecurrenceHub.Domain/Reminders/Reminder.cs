using ErrorOr;

namespace RecurrenceHub.Domain.Reminders;

public class Reminder : Entity
{
    public Guid UserId { get; }
    public Guid SubscriptionId { get; }
    public DateTimeOffset DateTime { get; }
    public DateOnly Date => DateOnly.FromDateTime(DateTime.Date);
    public string Text { get; } = default!;
    public bool IsDismissed { get; private set; }

    public Reminder(
        Guid userId,
        Guid subscriptionId,
        DateTimeOffset dateTime,
        string text,
        Guid? Id = null) : base(Id ?? Guid.NewGuid())
    {
        UserId = userId;
        SubscriptionId = subscriptionId;
        DateTime = dateTime;
        Text = text;
    }

    public ErrorOr<Success> Dismiss()
    {
        if (IsDismissed)
        {
            return Error.Conflict(description: "Reminder already dismissed.");
        }

        IsDismissed = true;
        return Result.Success;
    }

    private Reminder() { }
}

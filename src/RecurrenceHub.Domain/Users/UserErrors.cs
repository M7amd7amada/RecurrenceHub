using ErrorOr;

namespace RecurrenceHub.Domain.Users;

public static class UserErrors
{
    public static Error CannotCreateMoreRemindersThanSubscriptionAllows { get; } = Error.Validation(
        code: $"{nameof(UserErrors)}.{nameof(CannotCreateMoreRemindersThanSubscriptionAllows)}",
        description: "Cannot create more reminders than subscription allows.");
}
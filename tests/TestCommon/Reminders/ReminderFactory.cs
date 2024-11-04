using RecurrenceHub.Domain.Reminders;

using TestCommon.TestConstants;

namespace TestCommon.Reminders;

public static class ReminderFactory
{
    public static Reminder CreateReminder(
        Guid? userId = null,
        Guid? subscriptionId = null,
        string text = Constants.Reminder.Text,
        DateTime? dateTime = null,
        Guid? id = null)
    {
        return new Reminder(
            userId ?? Constants.User.Id,
            subscriptionId ?? Constants.Subscription.Id,
            dateTime ?? Constants.Reminder.DateTiem,
            text ?? Constants.Reminder.Text,
            id ?? Constants.Reminder.Id);
    }
}
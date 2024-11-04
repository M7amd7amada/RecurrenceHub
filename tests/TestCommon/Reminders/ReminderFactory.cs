using RecurrenceHub.Domain.Reminders;

namespace TestCommon.Reminders;

public static class ReminderFactory
{
    public static Reminder CreateReminder(
        Guid? userId = null,
        Guid? subscriptionId = null,
        string text = TestConstants.Constants.Reminder.Text,
        DateTime? date = null,
        Guid? id = null)
    {
        return new Reminder(
            userId,
            subscriptionId,
            date,
            text,
            id);
    }
}
namespace TestCommon.TestConstants;

public static partial class Constants
{
    public static class Reminder
    {
        public const string Text = "Remember to dimiss this reminder.";
        public static readonly Guid Id = Guid.NewGuid();
        public static readonly DateTime DateTiem = DateTime.UtcNow
            .AddDays(1).Date
            .AddHours(8);
    }
}
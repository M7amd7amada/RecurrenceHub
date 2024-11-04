using RecurrenceHub.Application.Common.Security.Permissions;
using RecurrenceHub.Application.Common.Security.Roles;

namespace TestCommon.TestConstants;

public static partial class Constants
{
    public static class User
    {
        public const string FirstName = "Mohamed";
        public const string LastName = "Hamada";
        public const string Email = "m7amd7amada@gmail.com";
        public static readonly Guid Id = Guid.NewGuid();

        public static readonly ICollection<string> Permissions = [
            Permission.Reminder.Set,
            Permission.Reminder.Get,
            Permission.Reminder.Delete,
            Permission.Reminder.Dismiss,
            Permission.Subscription.Get,
            Permission.Subscription.Create,
            Permission.Subscription.Delete,
        ];

        public static readonly ICollection<string> Roles = [
            Role.Admin,
        ];
    }
}
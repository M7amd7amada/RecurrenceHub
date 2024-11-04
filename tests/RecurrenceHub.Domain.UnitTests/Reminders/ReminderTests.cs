using ErrorOr;

using FluentAssertions;

using TestCommon.Reminders;

namespace RecurrenceHub.Domain.UnitTests.Reminders;

public class ReminderTests
{
    [Fact]
    public void CreateReminder_WhenConstructedSuccessfully_ShouldHaveIsDismissedFalse()
    {
        // Act
        var reminder = ReminderFactory.CreateReminder();

        // Assert
        reminder.IsDismissed.Should().BeFalse();
    }

    [Fact]
    public void DismissReminder_WhenReminderNotDismissed_ShouldDismissReminder()
    {
        // Arrange
        var reminder = ReminderFactory.CreateReminder();

        // Act
        var dimissedReminderResult = reminder.Dismiss();

        // Assert
        dimissedReminderResult.IsError.Should().BeFalse();
        reminder.IsDismissed.Should().BeTrue();
    }

    [Fact]
    public void DismissReminder_WhenReminderAlreadyDimissed_ShouldReturnConflict()
    {
        // Arrange
        var reminder = ReminderFactory.CreateReminder();

        // Act
        var firstDimissedReminderResult = reminder.Dismiss();
        var secondDimissedReminderResult = reminder.Dismiss();

        // Assert
        firstDimissedReminderResult.IsError.Should().BeFalse();

        secondDimissedReminderResult.IsError.Should().BeTrue();
        secondDimissedReminderResult.FirstError.Type.Should().Be(ErrorType.Conflict);

        reminder.IsDismissed.Should().BeTrue();
    }
}
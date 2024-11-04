using ErrorOr;

using FluentAssertions;

using RecurrenceHub.Domain.Users;

using TestCommon.Reminders;
using TestCommon.Subscriptions;
using TestCommon.Users;

namespace RecurrenceHub.Domain.UnitTests.Users;

public class UserTests
{
    [Theory]
    [MemberData(nameof(ListSubscriptionsWithLimit))]
    public void SetReminder_WhenMoreThanSubscriptionAllows_ShouldFail(SubscriptionType subscriptionType)
    {
        // Arrange
        var subscription = SubscriptionFactory.CreateSubscription(subscriptionType: subscriptionType);
        var user = UserFactory.CreateUser(subscription: subscription);

        ArgumentNullException.ThrowIfNull(subscriptionType);

        var reminders = Enumerable.Range(0, subscriptionType.GetMaxDailyReminders + 1)
            .Select(_ => ReminderFactory.CreateReminder(subscriptionId: subscription.Id, id: Guid.NewGuid()));

        // Act
        var setReminderResults = reminders.Select(user.SetReminder).ToList();

        // Assert

        // Assert all reminders set successfully
        var allButLastReminderResult = setReminderResults[..^1];

        allButLastReminderResult.Should().AllSatisfy(
            setReminderResult => setReminderResult.Value.Should().Be(Result.Success));

        // Assert settings last reminder returned conflict
        var lastReminder = setReminderResults[^1];

        lastReminder.IsError.Should().BeTrue();
        lastReminder.FirstError.Should().Be(UserErrors.CannotCreateMoreRemindersThanSubscriptionAllows);
    }

    public static TheoryData<SubscriptionType> ListSubscriptionsWithLimit()
    {
        TheoryData<SubscriptionType> theoryData = [];

        SubscriptionType.List.Except([SubscriptionType.Pro]).ToList()
            .ForEach(theoryData.Add);

        return theoryData;
    }
}
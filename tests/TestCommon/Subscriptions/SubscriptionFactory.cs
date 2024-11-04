using RecurrenceHub.Domain.Users;

using TestCommon.TestConstants;

namespace TestCommon.Subscriptions;

public static class SubscriptionFactory
{
    public static Subscription CreateSubscription(
        SubscriptionType? subscriptionType = null,
        Guid? id = null)
    {
        return new Subscription(
            subscriptionType ?? Constants.Subscription.SubscriptionType,
            id ?? Constants.Subscription.Id);
    }
}

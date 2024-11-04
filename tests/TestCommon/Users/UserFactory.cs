using RecurrenceHub.Domain.Users;

using TestCommon.Subscriptions;
using TestCommon.TestConstants;

namespace TestCommon.Users;

public static class UserFactory
{
    public static User CreateUser(
        Guid? id = null,
        string firstName = Constants.User.FirstName,
        string lastName = Constants.User.LastName,
        string email = Constants.User.Email,
        Subscription? subscription = null)
    {
        return new User(
            id ?? Constants.User.Id,
            firstName ?? Constants.User.FirstName,
            lastName ?? Constants.User.LastName,
            email ?? Constants.User.Email,
            subscription ?? SubscriptionFactory.CreateSubscription());
    }
}
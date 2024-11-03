namespace RecurrenceHub.Domain.Users;

public class Subscription : Entity
{
    public SubscriptionType SubscriptionType { get; } = null!;

    public Subscription(
        SubscriptionType subscriptionType,
        Guid? Id = null) : base(Id ?? Guid.NewGuid())
    {
        SubscriptionType = subscriptionType;
    }

    public static readonly Subscription Canceled
        = new(new SubscriptionType(nameof(Canceled), -1), Guid.Empty);

    private Subscription() { }
}
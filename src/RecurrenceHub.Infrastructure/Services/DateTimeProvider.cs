using RecurrenceHub.Application.Common.Interfaces.Services;

namespace RecurrenceHub.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

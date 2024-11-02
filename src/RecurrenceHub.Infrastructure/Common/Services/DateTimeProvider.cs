using RecurrenceHub.Application.Common.Interfaces.Services;

namespace RecurrenceHub.Infrastructure.Common.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

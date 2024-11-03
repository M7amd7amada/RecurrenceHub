namespace RecurrenceHub.Domain.Users;

public class Calender
{
    /// <summary>
    /// day -> numEvents.
    /// </summary>
    private readonly Dictionary<DateOnly, int> _calender = [];

    public static Calender Empty()
    {
        return new Calender();
    }

    public void IncrementEventCount(DateOnly date)
    {
        if (!_calender.TryGetValue(date, out _))
        {
            _calender[date] = 0;
        }

        _calender[date]++;
    }

    public void DecrementEventCount(DateOnly date)
    {
        if (!_calender.TryGetValue(date, out _))
        {
            return;
        }

        _calender[date]--;
    }

    public void SetEventCount(DateOnly date, int numEvents)
    {
        _calender[date] = numEvents;
    }

    public int GetNumEventsOnDay(DateTimeOffset dateTime)
    {
        return _calender.TryGetValue(DateOnly.FromDateTime(dateTime.Date), out var numEvents)
            ? numEvents
            : 0;
    }

    private Calender() { }
}
namespace TodoApp.Clock;

public interface IClockInterface
{
    public DateOnly GetToday();

    public string GetDayOfWeekString(DateOnly date);

    public IEnumerable<DateOnly> GetWeek(int differenceWithCurrent);
    public IEnumerable<DateOnly> GetMonth(int monthNumber);
}
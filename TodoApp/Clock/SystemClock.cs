namespace TodoApp.Clock;

public class SystemClock : IClockInterface
{
    private static readonly List<string> _daysOfWeek =
    [
        "Niedziela",
        "Poniedziałek",
        "Wtorek",
        "Środa",
        "Czwartek",
        "Piątek",
        "Sobota",
        "Niedziela"
    ];

    public DateOnly GetToday()
    {
        return DateOnly.FromDateTime(DateTime.Today);
    }

    public string GetDayOfWeekString(DateOnly date)
    {
        int dayNumber = (int)date.DayOfWeek;
        return _daysOfWeek[dayNumber];
    }

    public IEnumerable<DateOnly> GetWeek(int differenceWithCurrent)
    {
        List<DateOnly> week = new();

        DateOnly closestMonday = GetToday().AddDays(
            -(((int)GetToday().DayOfWeek + 6) % 7)
        );

        DateOnly startOfTheWeek = closestMonday.AddDays(7 * differenceWithCurrent);
        week.Add(startOfTheWeek);
        for (int i = 1; i < 7; i++)
        {
            week.Add(startOfTheWeek.AddDays(i));
        }

        return week;
    }

    public IEnumerable<DateOnly> GetMonth(int monthNumber)
    {
        List<DateOnly> month = new List<DateOnly>();
        if (monthNumber > 12)
            throw new ArgumentOutOfRangeException();

        List<int> shortMonths = new List<int>([2, 4, 6, 9, 11]);


        DateOnly firstDayOfYear = DateOnly.FromDateTime(new DateTime(DateTime.Now.Year, 01, 01));
        DateOnly firstDayOfMonth = firstDayOfYear;

        for (int i = 1; i <= 12; i++)
        {
            if (i == monthNumber)
                break;
            int days = (shortMonths.Contains(i)) ? 30 : 31;
            firstDayOfMonth = firstDayOfMonth.AddDays(days);
        }

        int daysOfMonth = (shortMonths.Contains(monthNumber)) ? 30 : 31;

        for (int i = 1; i <= daysOfMonth; i++)
        {
            month.Add(firstDayOfMonth.AddDays(i));
        }

        return month;
    }
}
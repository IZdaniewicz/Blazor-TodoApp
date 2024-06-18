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

    public DateOnly GetWeekStart()
    {
        return GetToday().AddDays(
            -(((int)GetToday().DayOfWeek + 6) % 7)
        );
    }

    public DateOnly GetWeekEnd()
    {
        return GetWeekStart().AddDays(6);
    }

    public DateOnly GetMonthStart()
    {
        return new DateOnly(
            DateTime.Now.Year, DateTime.Now.Month, 01
        );
    }

    public DateOnly GetMonthEnd()
    {
        List<int> shortMonths = [2, 4, 6, 9, 11];
        int day;

        if (shortMonths.Contains(DateTime.Now.Month))
        {
            day = 30;
        }
        else
        {
            day = 31;
        }

        return new DateOnly(
            DateTime.Now.Year, DateTime.Now.Month, day
        );
    }
}
namespace TodoApp.Clock;

public interface IClockInterface
{
    public DateOnly GetToday();

    public DateOnly GetWeekStart();
    public DateOnly GetWeekEnd();
    public DateOnly GetMonthStart();
    public DateOnly GetMonthEnd();
}
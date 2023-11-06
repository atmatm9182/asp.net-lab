namespace lab3_App.Models;

public class CurrentDateTimeProvider : IDateTimeProvider
{
    public DateTime GetTime() => DateTime.Now;
}
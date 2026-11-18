namespace asp_lesson_introduction.Loggers;

public class CustomLogger : ICustomLogger
{
    public void Info(string message)
    {
        Console.WriteLine($"[INFO] {message}");
    }
}
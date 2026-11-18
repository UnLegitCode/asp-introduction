namespace asp_lesson_introduction.Senders;

public class ConsoleSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"[CONSOLE] {message}");
    }
}
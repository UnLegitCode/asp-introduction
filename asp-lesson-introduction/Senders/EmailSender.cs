namespace asp_lesson_introduction.Senders;

public class EmailSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"[EMAIL] {message}");
    }
}
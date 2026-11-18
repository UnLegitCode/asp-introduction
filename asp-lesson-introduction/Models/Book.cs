namespace asp_lesson_introduction.Models;

public class Book(string title, string author)
{
    public int Id { get; set; } = -1;
    public string Title { get; set; } = title;
    public string Author { get; set; } = author;
}
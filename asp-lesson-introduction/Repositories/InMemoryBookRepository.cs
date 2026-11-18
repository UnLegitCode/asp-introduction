using asp_lesson_introduction.Models;

namespace asp_lesson_introduction.Repositories;

public class InMemoryBookRepository : IBookRepository
{
    private readonly Dictionary<int, Book> _books = new();
    private int _idCounter = 1;
    
    public List<Book> FindAll() => _books.Values.ToList();

    public Book? FindById(int id)
    {
        return _books.GetValueOrDefault(id, null);
    }

    public Book Save(Book book)
    {
        if (book.Id == -1)
        {
            book.Id = _idCounter++;
            _books.Add(book.Id, book);
        }
        else
        {
            _books[book.Id] = book;
        }

        return book;
    }

    public void DeleteById(int id) => _books.Remove(id);
}
using asp_lesson_introduction.Models;

namespace asp_lesson_introduction.Services;

public interface IBookService
{
    List<Book> ListBooks();

    Book GetBookById(int id);

    Book CreateBook(string title, string author);

    Book UpdateBook(Book book);

    void DeleteBookById(int id);
}
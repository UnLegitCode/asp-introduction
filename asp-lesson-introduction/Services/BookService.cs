using asp_lesson_introduction.Exceptions;
using asp_lesson_introduction.Loggers;
using asp_lesson_introduction.Models;
using asp_lesson_introduction.Repositories;

namespace asp_lesson_introduction.Services;

public class BookService(
    IBookRepository repository, IServiceProvider serviceProvider
) : IBookService {
    public List<Book> ListBooks() => repository.FindAll();

    public Book GetBookById(int id)
    {
        var book = repository.FindById(id);

        return book ?? throw new BookNotFoundException(id);
    }

    public Book CreateBook(string title, string author)
    {
        var logger = serviceProvider.GetRequiredService<ICustomLogger>();
        
        logger.Info("Creating new book");
        
        var book = new Book(title, author);
        
        return repository.Save(book);
    }

    public Book UpdateBook(Book book) => repository.Save(book);

    public void DeleteBookById(int id) => repository.DeleteById(id);
}
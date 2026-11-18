using asp_lesson_introduction.Models;

namespace asp_lesson_introduction.Repositories;

public interface IBookRepository
{
    List<Book> FindAll();
    
    Book? FindById(int id);

    Book Save(Book book);

    void DeleteById(int id);
}
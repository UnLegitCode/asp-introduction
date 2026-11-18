namespace asp_lesson_introduction.Exceptions;

public class BookNotFoundException(
    int bookId
) : Exception($"No book with id: {bookId}");
using asp_lesson_introduction.DTOs;
using asp_lesson_introduction.Exceptions;
using asp_lesson_introduction.Models;
using asp_lesson_introduction.Services;

namespace asp_lesson_introduction.Routes;

public static class BookRoutes
{
    public static void MapBooks(this IEndpointRouteBuilder endpoints)
    {
        endpoints.Map("/books", async (HttpContext context, IBookService bookService) =>
        {
            switch (context.Request.Method)
            {
                case "GET":
                {
                    await context.Response.WriteAsJsonAsync(bookService.ListBooks());
                    break;
                }
                case "POST":
                {
                    var dto = await context.Request.ReadFromJsonAsync<BookCreateDto>();

                    if (dto == null)
                    {
                        context.Response.StatusCode = 400;
                    }
                    else
                    {
                        var book = bookService.CreateBook(dto.Title, dto.Author);

                        context.Response.StatusCode = 201;
                        await context.Response.WriteAsJsonAsync(book);
                    }

                    break;
                }
                case "PUT":
                {
                    var book = await context.Request.ReadFromJsonAsync<Book>();

                    if (book == null)
                    {
                        context.Response.StatusCode = 400;
                    }
                    else
                    {
                        book = bookService.UpdateBook(book);

                        await context.Response.WriteAsJsonAsync(book);
                    }

                    break;
                }
                default:
                {
                    context.Response.StatusCode = 405;
                    break;
                }
            }
        });

        endpoints.Map("/books/{id:int}", async (HttpContext context, IBookService bookService, int id) =>
        {
            switch (context.Request.Method)
            {
                case "GET":
                {
                    try
                    {
                        var book = bookService.GetBookById(id);

                        await context.Response.WriteAsJsonAsync(book);
                    }
                    catch (BookNotFoundException exception)
                    {
                        context.Response.StatusCode = 404;
                        await context.Response.WriteAsJsonAsync(exception.Message);
                    }

                    break;
                }
                case "DELETE":
                {
                    bookService.DeleteBookById(id);

                    context.Response.StatusCode = 204;

                    break;
                }
                default:
                {
                    context.Response.StatusCode = 405;
                    break;
                }
            }
        });
    }
}
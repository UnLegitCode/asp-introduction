using asp_lesson_introduction.Loggers;
using asp_lesson_introduction.Repositories;
using asp_lesson_introduction.Routes;
using asp_lesson_introduction.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICustomLogger, CustomLogger>();
builder.Services.AddSingleton<IBookRepository, InMemoryBookRepository>();
builder.Services.AddSingleton<IBookService, BookService>();

// builder.Services.AddSingleton<IMessageSender, EmailSender>();
// builder.Services.AddSingleton<IMessageSender, ConsoleSender>();

var app = builder.Build();

// app.UseCustomMiddlewarePipeline();

app.MapBooks();

// app.Map("/", async (HttpContext context, IEnumerable<IMessageSender> messageSenders) =>
// {
//     foreach (var messageSender in messageSenders)
//     {
//         messageSender.SendMessage("Hello World!");
//     }
//     
//     await context.Response.WriteAsync("Hello World!");
// });

app.Run();
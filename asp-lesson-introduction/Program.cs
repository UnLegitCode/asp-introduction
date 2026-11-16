using asp_lesson_introduction.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseExceptionHandler();
app.UseToken("1234");
app.UseCustomRouting();

app.Map("/", async (HttpContext context) =>
{
    return new List<User>([
        new User("Ivan", "Ivanov", 25),
        new User("Petr", "Petrov", 30),
        new User("Dmitriy", "Sidorov", 35),
    ]);
});

app.Run();

public record User(string FirstName, string LastName, int Age);
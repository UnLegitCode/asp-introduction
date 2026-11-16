namespace asp_lesson_introduction.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        await next(context);

        var statusCode = context.Response.StatusCode;

        switch (statusCode)
        {
            case 401:
            {
                await context.Response.WriteAsync("401 Invalid authentication credentials");
                break;
            }
            case 404:
            {
                await context.Response.WriteAsync("404 Page Not Found :(((");
                break;
            }
            case 405:
            {
                await context.Response.WriteAsync("405 Method Not Allowed");
                break;
            }
        }
    }
}
namespace asp_lesson_introduction.Middlewares;

public class TokenMiddleware(RequestDelegate next, string expectedToken)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Query["token"];

        if (token == expectedToken)
        {
            await next(context);
        }
        else
        {
            context.Response.StatusCode = 401;
        }
    }
}
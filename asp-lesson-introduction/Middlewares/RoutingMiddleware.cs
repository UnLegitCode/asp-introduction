namespace asp_lesson_introduction.Middlewares;

public class RoutingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Method != "GET")
        {
            context.Response.StatusCode = 405;
            return;
        }
        
        var path = context.Request.Path;

        if (path == "/" || path == "/index")
        {
            await context.Response.WriteAsync("Main page");
        } else if (path == "/about")
        {
            await context.Response.WriteAsync("About page");
        }
        else
        {
            context.Response.StatusCode = 404;
        }
    }
}
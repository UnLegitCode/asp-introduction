namespace asp_lesson_introduction.Middlewares;

public static class CustomMiddlewareExtensions
{
    public static IApplicationBuilder UseToken(
        this IApplicationBuilder app, string expectedToken
    ) {
        return app.UseMiddleware<TokenMiddleware>(expectedToken);
    }

    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }

    public static IApplicationBuilder UseCustomRouting(this IApplicationBuilder app)
    {
        return app.UseMiddleware<RoutingMiddleware>();
    }
}
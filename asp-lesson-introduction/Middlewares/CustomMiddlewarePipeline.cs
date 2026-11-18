using System.Runtime.CompilerServices;

namespace asp_lesson_introduction.Middlewares;

public static class CustomMiddlewarePipeline
{
    public static IApplicationBuilder UseCustomMiddlewarePipeline(
        this IApplicationBuilder builder
    ) {
        builder.Use(async (_, next) =>
        {
            Console.WriteLine(">>> Main pipeline before");
    
            await next();
    
            Console.WriteLine(">>> Main pipeline after");
        });

        builder.MapWhen( // Или UseWhen
            context => context.Request.Path.StartsWithSegments("/api"),
            apiBranch =>
            {
                apiBranch.Use(async (_, next) =>
                {
                    Console.WriteLine(">>> API branch handling");
            
                    await next();
                });
        
                // Этот терминальный обработчик можно закомментировать
                apiBranch.Run(async context =>
                {
                    await context.Response.WriteAsync("Response from API");
                });
            }
        );

        builder.Run(async (context) =>
        {
            Console.WriteLine(">>> Terminal handler for main branch");
    
            await context.Response.WriteAsync("Response from main branch");
        });

        return builder;
    }
}
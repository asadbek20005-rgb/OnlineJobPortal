namespace OnlineJobPortal.Api.CustomMiddlewares.Extensions;

public static class ExtensionMiddlewareHandlerExtension
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}   

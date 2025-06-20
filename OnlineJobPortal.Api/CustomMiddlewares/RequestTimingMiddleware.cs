using System.Diagnostics;

namespace OnlineJobPortal.Api.CustomMiddlewares;

public class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestTimingMiddleware> _logger;

    public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        await _next(context);

        stopwatch.Stop();

        var elapsedTime = stopwatch.ElapsedMilliseconds;

        _logger.LogInformation($"[{DateTime.UtcNow}] {context.Request.Method} {context.Request.Path} executed in {elapsedTime} ms");

        context.Response.Headers.Add("X-Response-Time-ms", elapsedTime.ToString());
    }
}

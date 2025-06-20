using OnlineJobPortal.Common.Statics;
using OnlineJobPortal.Data.Contexts;
using OnlineJobPortal.Data.Entities;
using System.Diagnostics;

namespace OnlineJobPortal.Api.CustomMiddlewares;

public class LogingMiddleware
{
    private readonly RequestDelegate _next;



    public LogingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, OnlineJobPortalDbContext dbContext)
    {
        string message;
        string level;
        var watch = Stopwatch.StartNew();

        try
        {
            await _next(context);
        }
        finally
        {
            watch.Stop();

            if (context.Response.StatusCode < 400)
            {
                level = LogLevelData.Info;
                message = "Request completed successfully.";

            }
            else if (context.Response.StatusCode < 500)
            {
                level = "Warning";
                message = "Client made a bad request.";
            }
            else
            {
                level = "Error";
                message = "Server error occurred.";
            }


            var log = new Log
            {
                Level = level,
                Message = message,
                Timestamp = DateTime.UtcNow,
                Path = context.Request.Path,
                Method = context.Request.Method,
                StatusCode = context.Response.StatusCode
            };

            await dbContext.Logs.AddAsync(log);
            await dbContext.SaveChangesAsync();
        }
    }
}

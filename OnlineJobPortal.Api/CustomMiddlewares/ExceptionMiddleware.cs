using Newtonsoft.Json;
using OnlineJobPortal.Service.Exceptions;

namespace OnlineJobPortal.Api.CustomMiddlewares;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (CodeIsExpiredException ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message, 400);
        }
        catch (InvalidPhoneNumberOrCode ex)
        {
            await HandleExceptionAsync(httpContext, ex.Message, 400);
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
            {
                _logger.LogError(ex.InnerException.GetType().ToString(), ex.InnerException.Message);
            }
            else
            {
                _logger.LogError(ex.GetType().ToString(), ex.Message);
            }

            await httpContext.Response.WriteAsync("Error occured");
        }
    }


    private static Task HandleExceptionAsync(HttpContext httpContext, string message, int statusCode)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
        return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new
        {
            error = message
        }));
    }
}

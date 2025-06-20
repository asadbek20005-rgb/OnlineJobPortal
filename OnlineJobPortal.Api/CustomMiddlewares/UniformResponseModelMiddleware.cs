using OnlineJobPortal.Common.Results;

namespace OnlineJobPortal.Api.CustomMiddlewares;

public class UniformResponseModelMiddleware
{
    private readonly RequestDelegate _next;

    public UniformResponseModelMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var originalBody = context.Response.Body;
        using var newBody = new MemoryStream();
        context.Response.Body = newBody;

        try
        {
            await _next(context);

            newBody.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(newBody).ReadToEndAsync();

            context.Response.Body = originalBody;
            context.Response.ContentType = "application/json";

            object? responseData = null;
            if (!string.IsNullOrWhiteSpace(responseBody) && context.Response.StatusCode < 400)
            {
                responseData = Result<string>.SuccessResult(responseBody);
            }
            else if (context.Response.StatusCode >= 400)
            {
                responseData = Result<string>.Failure(responseBody);
            }

            await context.Response.WriteAsJsonAsync(responseData);
        }
        catch (Exception ex)
        {
            context.Response.Body = originalBody;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            var error = Result<string>.Failure("Server error: " + ex.Message);
            await context.Response.WriteAsJsonAsync(error);
        }
    }
}

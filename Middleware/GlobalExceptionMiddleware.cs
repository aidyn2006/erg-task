using System.Net;
using ERG_Task.Exception;
using Microsoft.AspNetCore.Mvc;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        
        catch (NotFoundException ex)
        {
            _logger.LogError($"Unhandled exception: {ex.Message}");
            context.Response.StatusCode = (int)HttpStatusCode.NoContent;

            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.NoContent,
                Type = "Not Found",
                Title = "Not found because doesnt exist in the database",
                Detail = ex.Message
            };

            await HandleException(context, problemDetails);
        }
    }

    private async Task HandleException(HttpContext context, ProblemDetails problemDetails)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = problemDetails.Status ?? (int)HttpStatusCode.InternalServerError;

        await context.Response.WriteAsJsonAsync(problemDetails);
    }
}

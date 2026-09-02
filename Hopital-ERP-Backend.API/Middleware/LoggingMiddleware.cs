using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Hospital_ERP_Backend.API.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(
        RequestDelegate next,
        ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        var originalBodyStream = context.Response.Body;

        await using var responseBody = new MemoryStream();

        context.Response.Body = responseBody;

        try
        {
            await _next(context);
        }
        finally
        {
            stopwatch.Stop();

            var message = await GetResponseMessageAsync(context);

            LogRequest(
                context,
                message,
                stopwatch.ElapsedMilliseconds);

            responseBody.Seek(0, SeekOrigin.Begin);

            await responseBody.CopyToAsync(originalBodyStream);

            context.Response.Body = originalBodyStream;
        }
    }

    private static async Task<string?> GetResponseMessageAsync(
        HttpContext context)
    {
        context.Response.Body.Seek(0, SeekOrigin.Begin);

        using var reader = new StreamReader(
            context.Response.Body,
            Encoding.UTF8,
            leaveOpen: true);

        var body = await reader.ReadToEndAsync();

        context.Response.Body.Seek(0, SeekOrigin.Begin);

        if (string.IsNullOrWhiteSpace(body))
            return null;

        try
        {
            using var json = JsonDocument.Parse(body);

            if (json.RootElement.TryGetProperty(
                    "message",
                    out var message))
            {
                return message.GetString();
            }

            if (json.RootElement.TryGetProperty(
                    "Message",
                    out message))
            {
                return message.GetString();
            }
        }
        catch (JsonException)
        {
            // Response is not JSON.
        }

        return null;
    }

    private void LogRequest(
        HttpContext context,
        string? message,
        long elapsedMilliseconds)
    {
        var method = context.Request.Method;
        var path = context.Request.Path;
        var statusCode = context.Response.StatusCode;

        // Don't log successful GET requests.
        if (method == HttpMethods.Get &&
            statusCode >= 200 &&
            statusCode < 300)
        {
            return;
        }

        if (statusCode >= 200 && statusCode < 300)
        {
            _logger.LogInformation(
                "{Method} {Path} | {StatusCode} | {Message} | {ElapsedMs}ms",
                method,
                path,
                statusCode,
                message ?? "Request completed successfully",
                elapsedMilliseconds);

            return;
        }

        if (statusCode >= 400 && statusCode < 500)
        {
            _logger.LogWarning(
                "{Method} {Path} | {StatusCode} | {Message} | {ElapsedMs}ms",
                method,
                path,
                statusCode,
                message ?? "Request failed",
                elapsedMilliseconds);

            return;
        }

        if (statusCode >= 500)
        {
            _logger.LogError(
                "{Method} {Path} | {StatusCode} | {Message} | {ElapsedMs}ms",
                method,
                path,
                statusCode,
                message ?? "Internal server error",
                elapsedMilliseconds);
        }
    }
}
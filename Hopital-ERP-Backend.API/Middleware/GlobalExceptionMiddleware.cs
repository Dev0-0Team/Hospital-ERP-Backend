using System.Security.Authentication;
using Hospital_ERP_Backend.API.Exceptions;

namespace Hospital_ERP_Backend.API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            int statusCode;
            string message;

            switch (exception)
            {
                case ArgumentOutOfRangeException ex:
                    statusCode = StatusCodes.Status400BadRequest;
                    message = ex.Message;
                    break;

                case ArgumentNullException ex:
                    statusCode = StatusCodes.Status400BadRequest;
                    message = ex.Message;
                    break;

                case ArgumentException ex:
                    statusCode = StatusCodes.Status400BadRequest;
                    message = ex.Message;
                    break;

                case KeyNotFoundException ex:
                    statusCode = StatusCodes.Status404NotFound;
                    message = ex.Message;
                    break;

                case InvalidOperationException ex:
                    statusCode = StatusCodes.Status409Conflict;
                    message = ex.Message;
                    break;

                case AuthenticationException ex:
                    statusCode = StatusCodes.Status401Unauthorized;
                    message = ex.Message;
                    break;

                case UnauthorizedAccessException ex:
                    statusCode = StatusCodes.Status403Forbidden;
                    message = ex.Message;
                    break;

                case FormatException ex:
                    statusCode = StatusCodes.Status400BadRequest;
                    message = ex.Message;
                    break;

                case TooManyRequestsException ex:
                    statusCode = StatusCodes.Status429TooManyRequests;
                    message = ex.Message;
                    break;

                default:
                    statusCode = StatusCodes.Status500InternalServerError;

                    message = _env.IsDevelopment()
                        ? exception.Message
                        : "An unexpected error occurred.";

                    break;
            }

            context.Response.StatusCode = statusCode;

            var response = new
            {
                statusCode,
                message,
                data = (object?)null
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
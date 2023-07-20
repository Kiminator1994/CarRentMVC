namespace CarRent.Data
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Threading.Tasks;

    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Handle the exception here
                // You can log the exception, display a custom error page, or return a user-friendly response.

                // For demonstration purposes, we'll set a custom response message.
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Oops! Something went wrong. Please try again later.");
            }
        }
    }
}


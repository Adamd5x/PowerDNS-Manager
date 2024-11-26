using Microsoft.AspNetCore.Diagnostics;

namespace hiPower.WebApi.Middlewares
{
    public class ExceptionHandler (ILogger<ExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync (HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            logger.LogError (exception, "Application error");

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = MediaTypeNames.Application.Json;

            await httpContext.Response.WriteAsJsonAsync (exception, cancellationToken).ConfigureAwait (false);

            return true;
        }
    }
}

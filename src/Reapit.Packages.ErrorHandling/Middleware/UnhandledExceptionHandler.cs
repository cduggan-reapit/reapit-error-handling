using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Reapit.Packages.ErrorHandling.Errors;
using Reapit.Packages.ErrorHandling.Providers;

namespace Reapit.Packages.ErrorHandling.Middleware;

/// <summary>
/// Middleware class generating responses for unhandled exceptions
/// </summary>
public class UnhandledExceptionHandler : IExceptionHandler
{
    private readonly ILogger<UnhandledExceptionHandler> _logger;
    
    /// <summary>
    /// Initialize a new instance of the <see cref="UnhandledExceptionHandler"/> class
    /// </summary>
    /// <param name="logger"></param>
    public UnhandledExceptionHandler(ILogger<UnhandledExceptionHandler> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc />
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError($"{DateTimeOffsetProvider.Now:s}: {exception.GetType().Name} ({exception.Message})");
        var errorModel = ApplicationErrorModel.FromException(exception);

        httpContext.Response.StatusCode = 500;
        await httpContext.Response.WriteAsJsonAsync(errorModel, cancellationToken);
        return true;
    }
}
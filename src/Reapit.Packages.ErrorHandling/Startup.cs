using Microsoft.Extensions.DependencyInjection;
using Reapit.Packages.ErrorHandling.Middleware;

namespace Reapit.Packages.ErrorHandling;

/// <summary>
/// Service registration methods for the <see cref="ErrorHandling"/> project
/// </summary>
public static class Startup
{
    /// <summary>
    /// Register error handling services in the application service collection
    /// </summary>
    /// <param name="services">The application service collection</param>
    public static IServiceCollection RegisterErrorHandlerServices(this IServiceCollection services)
    {
        services.AddExceptionHandler<UnhandledExceptionHandler>();
        return services;
    }
}
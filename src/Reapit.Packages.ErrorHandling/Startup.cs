using Microsoft.Extensions.DependencyInjection;
using Reapit.Packages.ErrorHandling.Middleware;

namespace Reapit.Packages.ErrorHandling;

public static class Startup
{
    public static IServiceCollection RegisterErrorHandlerServices(this IServiceCollection services)
    {
        services.AddExceptionHandler<UnhandledExceptionHandler>();
        return services;
    }
}
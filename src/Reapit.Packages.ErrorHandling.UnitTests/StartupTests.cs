using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Reapit.Packages.ErrorHandling.Middleware;

namespace Reapit.Packages.ErrorHandling.UnitTests;

public class StartupTests
{
    // RegisterErrorHandlerServices
    
    [Fact]
    public void RegisterErrorHandlerServices_AddsServices_ToGivenContainer()
    {
        var container = GetServiceCollection();
        container.RegisterErrorHandlerServices();
        
        using var provider = container.BuildServiceProvider();
        
        // Check that the exception handler is registered in the service collection
        var exceptionHandler = provider.GetRequiredService<IExceptionHandler>();
        exceptionHandler.Should().NotBeNull();
        exceptionHandler.GetType().Should().Be(typeof(UnhandledExceptionHandler));
    }
    
    // Private methods

    private static IServiceCollection GetServiceCollection()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        return services;
    }
}
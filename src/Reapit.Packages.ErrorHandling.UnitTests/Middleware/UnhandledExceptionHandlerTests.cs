using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Reapit.Packages.ErrorHandling.Errors;
using Reapit.Packages.ErrorHandling.Middleware;
using Reapit.Packages.ErrorHandling.Providers;

namespace Reapit.Packages.ErrorHandling.UnitTests.Middleware;

public class UnhandledExceptionHandlerTests
{
    private readonly ILogger<UnhandledExceptionHandler> _logger = Substitute.For<ILogger<UnhandledExceptionHandler>>();
    
    // TryHandleAsync

    [Fact]
    public async Task TryHandleAsync_WritesExceptionModel_ToResponseBody()
    {
        const string message = "test exception";
        var exception = new ApplicationException(message);
        
        var timestamp = new DateTimeOffset(2024, 2, 22, 11, 49, 51, TimeSpan.FromHours(2));
        using var ambientContext = new DateTimeOffsetProviderContext(timestamp);
        
        var httpContext = new DefaultHttpContext { Response = { Body = new MemoryStream() } };
        var expectedLog = $"{DateTimeOffsetProvider.Now:s}: {exception.GetType().Name} ({exception.Message})";
        var expectedBody = JsonSerializer.Serialize(new { message = ApplicationErrorModel.ErrorMessage });
        
        var sut = CreateSut();
        
        var response = await sut.TryHandleAsync(httpContext, exception, default);
        response.Should().BeTrue();

        // Check the exception itself is logged once
        _logger.Received(1).LogError(expectedLog);
        
        // Check the StatusCode
        httpContext.Response.StatusCode.Should().Be(500);
        
        // Check the response body
        httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
        var reader = new StreamReader(httpContext.Response.Body);
        var content = await reader.ReadToEndAsync(default);
        content.Should().BeEquivalentTo(expectedBody);
    }

    // Private Methods
    
    private UnhandledExceptionHandler CreateSut()
        => new(_logger);
}
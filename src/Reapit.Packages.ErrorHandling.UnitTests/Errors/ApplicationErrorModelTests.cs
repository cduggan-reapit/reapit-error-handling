using Reapit.Packages.ErrorHandling.Errors;
using Reapit.Packages.ErrorHandling.Providers;

namespace Reapit.Packages.ErrorHandling.UnitTests.Errors;

public class ApplicationErrorModelTests
{
    // FromException

    [Fact]
    public void FromException_CreatesErrorModel_FromGivenExceptionProperties()
    {
        const string parameter = "argument";
        var exception = new ArgumentNullException(parameter);
        var timestamp = new DateTimeOffset(2013, 1, 7, 10, 15, 0, TimeSpan.FromHours(-6));
        
        using var ambientContext = new DateTimeOffsetProviderContext(timestamp);
        var model = ApplicationErrorModel.FromException(exception);

        model.Message.Should().BeEquivalentTo(ApplicationErrorModel.ErrorMessage);
        model.Timestamp.Should().Be(timestamp);
    }
}
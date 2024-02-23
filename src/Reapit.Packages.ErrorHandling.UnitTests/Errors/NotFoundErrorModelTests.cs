using Reapit.Packages.ErrorHandling.Errors;
using Reapit.Packages.ErrorHandling.Exceptions;
using Reapit.Packages.ErrorHandling.Providers;

namespace Reapit.Packages.ErrorHandling.UnitTests.Errors;

public class NotFoundErrorModelTests
{
    // FromException

    [Fact]
    public void FromException_CreatesErrorModel_FromGivenExceptionProperties()
    {
        var exception = new NotFoundException(typeof(Int64), "long");
        var timestamp = new DateTimeOffset(2013, 1, 7, 10, 15, 0, TimeSpan.FromHours(-6));
        
        using var ambientContext = new DateTimeOffsetProviderContext(timestamp);
        var model = NotFoundErrorModel.FromException(exception);

        model.Message.Should().BeEquivalentTo(NotFoundErrorModel.ErrorMessage );
        model.ResourceType.Should().BeEquivalentTo(exception.Type.Name);
        model.Id.Should().BeEquivalentTo(exception.Id);
        model.Timestamp.Should().Be(timestamp);
    }
}
using Reapit.Packages.ErrorHandling.Exceptions;

namespace Reapit.Packages.ErrorHandling.UnitTests.Exceptions;

public class ConflictExceptionTests
{
    // Ctor

    [Fact]
    public void Ctor_InitializesProperties_FromGivenParameters()
    {
        var type = typeof(string);
        const string identifier = "id";

        var exception = new ConflictException(type, identifier);

        exception.Type.Should().Be(type);
        exception.Id.Should().BeEquivalentTo(identifier);
        exception.Message.Should().BeEquivalentTo(ConflictException.ErrorMessage);
    }
}
using FluentValidation;
using FluentValidation.Results;
using Reapit.Packages.ErrorHandling.Errors;
using Reapit.Packages.ErrorHandling.Providers;

namespace Reapit.Packages.ErrorHandling.UnitTests.Errors;

public class ValidationErrorModelTests
{
    [Fact]
    public void FromException_CreatesErrorModel_FromValidationFailure()
    {
        var validationFailures = new List<ValidationFailure>
        {
            new ("propertyName1", "errorMessage1"),
            new ("propertyName2", "errorMessage2a"),
            new ("propertyName2", "errorMessage2b"),
            new ("propertyName3", "errorMessage3"),
            new ("", "globalError")
        };

        var expectedErrors = new Dictionary<string, IEnumerable<string>>
        {
            { "propertyName1", ["errorMessage1"] },
            { "propertyName2", ["errorMessage2a", "errorMessage2b"] },
            { "propertyName3", ["errorMessage3"] },
            { "", ["globalError"] }
        };

        var timestamp = new DateTimeOffset(2020, 6, 12, 17, 30, 0, TimeSpan.FromHours(-5));
        using var ambientContext = new DateTimeOffsetProviderContext(timestamp);

        var model = ValidationErrorModel.FromException(new ValidationException(validationFailures));

        model.Message.Should().BeEquivalentTo(ValidationErrorModel.ErrorMessage);
        model.Timestamp.Should().Be(timestamp);
        model.Errors.Should().BeEquivalentTo(expectedErrors);
    }
}
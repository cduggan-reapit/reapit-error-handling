using FluentValidation;
using Reapit.Packages.ErrorHandling.Errors.Abstract;

namespace Reapit.Packages.ErrorHandling.Errors;

/// <summary>
/// Error model representing a <see cref="ValidationException"/>
/// </summary>
public class ValidationErrorModel : BaseErrorModel
{
    internal const string ErrorMessage = "Validation failed";
    
    /// <summary>
    /// Collection of validation errors
    /// </summary>
    public Dictionary<string, IEnumerable<string>> Errors { get; }

    /// <summary>
    /// Initialize a new instance of the <see cref="ValidationErrorModel"/> class
    /// </summary>
    /// <param name="errors">The errors collection</param>
    private ValidationErrorModel(Dictionary<string, IEnumerable<string>> errors)
        : base(ErrorMessage)
        => Errors = errors;

    /// <summary>
    /// Factory method to create a new <see cref="ValidationErrorModel"/> from a <see cref="ValidationException"/>
    /// </summary>
    /// <param name="exception">The exception from which to build the error model</param>
    public static ValidationErrorModel FromException(ValidationException exception)
        => new(exception.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                keySelector: group => group.Key,
                elementSelector: group => group.Select(validationFailure => validationFailure.ErrorMessage)));
}
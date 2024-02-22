using Reapit.Packages.ErrorHandling.Errors.Abstract;

namespace Reapit.Packages.ErrorHandling.Errors;

/// <summary>
/// Error model representing a generic exception
/// </summary>
public class ApplicationErrorModel : BaseErrorModel
{
    internal const string ErrorMessage = "An unexpected error has occurred";
    
    /// <summary>
    /// The type of error
    /// </summary>
    public string ErrorType { get; private init; }
    
    /// <summary>
    /// Description of the error
    /// </summary>
    public string Exception { get; private init; }
    
    /// <summary>
    /// Initialize a new instance of the <see cref="ApplicationErrorModel"/> class
    /// </summary>
    /// <param name="errorType">The type of exception</param>
    /// <param name="exception">Description of the error</param>
    private ApplicationErrorModel(string errorType, string exception)
        : base(ErrorMessage)
    {
        ErrorType = errorType;
        Exception = exception;
    }

    /// <summary>
    /// Factory method to create a new <see cref="ApplicationErrorModel"/> from an <see cref="Exception"/>
    /// </summary>
    /// <param name="exception">The exception from which to build the error model</param>
    public static ApplicationErrorModel FromException(Exception exception)
        => new(exception.GetType().Name, exception.Message);
}
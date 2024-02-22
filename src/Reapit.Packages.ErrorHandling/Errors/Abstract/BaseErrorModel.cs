using Reapit.Packages.ErrorHandling.Providers;

namespace Reapit.Packages.ErrorHandling.Errors.Abstract;

/// <summary>
/// Base class for error models
/// </summary>
public abstract class BaseErrorModel
{
    /// <summary>
    /// Description of the error
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Timestamp of the error
    /// </summary>
    public DateTimeOffset Timestamp = DateTimeOffsetProvider.Now;

    /// <summary>
    /// Initialize a new instance of the <see cref="BaseErrorModel"/> class
    /// </summary>
    /// <param name="message">Description of the error</param>
    protected BaseErrorModel(string message)
        => Message = message;
}
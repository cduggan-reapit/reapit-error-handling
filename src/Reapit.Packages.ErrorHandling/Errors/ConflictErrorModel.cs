using Reapit.Packages.ErrorHandling.Errors.Abstract;
using Reapit.Packages.ErrorHandling.Exceptions;

namespace Reapit.Packages.ErrorHandling.Errors;

/// <summary>
/// Error model representing a precondition test failure
/// </summary>
public class ConflictErrorModel : BaseErrorModel
{
    internal const string ErrorMessage = "Concurrency check failed";
    
    /// <summary>
    /// Unique identifier of the resource
    /// </summary>
    public string Id { get; }
    
    /// <summary>
    /// The type of resource
    /// </summary>
    public string ResourceType { get; }

    /// <summary>
    /// Initialize a new instance of the <see cref="ConflictErrorModel"/> class
    /// </summary>
    /// <param name="resourceType">The type of resource</param>
    /// <param name="resourceIdentifier">Unique identifier of the resource</param>
    private ConflictErrorModel(string resourceType, string resourceIdentifier)
        : base(ErrorMessage)
    {
        Id = resourceIdentifier;
        ResourceType = resourceType;
    }

    /// <summary>
    /// Factory method to create a new <see cref="ConflictErrorModel"/> from a <see cref="ConflictException"/>
    /// </summary>
    /// <param name="exception">The exception from which to build the error model</param>
    public static ConflictErrorModel FromException(ConflictException exception)
        => new(exception.Type.Name, exception.Id);
}
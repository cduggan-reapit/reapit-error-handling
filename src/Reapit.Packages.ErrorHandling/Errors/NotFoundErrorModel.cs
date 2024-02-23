using Reapit.Packages.ErrorHandling.Errors.Abstract;
using Reapit.Packages.ErrorHandling.Exceptions;

namespace Reapit.Packages.ErrorHandling.Errors;

/// <summary>
/// Error model representing a <see cref="NotFoundException"/> 
/// </summary>
public class NotFoundErrorModel : BaseErrorModel
{
    internal const string ErrorMessage = "Resource not found";
    
    /// <summary>
    /// Unique identifier of the resource
    /// </summary>
    public string Id { get; }
    
    /// <summary>
    /// The type of resource
    /// </summary>
    public string ResourceType { get; }

    /// <summary>
    /// Initialize a new instance of the <see cref="NotFoundErrorModel"/> class
    /// </summary>
    /// <param name="resourceType">The type of resource</param>
    /// <param name="resourceIdentifier">Unique identifier of the resource</param>
    private NotFoundErrorModel(string resourceType, string resourceIdentifier)
        : base(ErrorMessage)
    {
        Id = resourceIdentifier;
        ResourceType = resourceType;
    }

    /// <summary>
    /// Factory method to create a new <see cref="NotFoundErrorModel"/> from a <see cref="NotFoundException"/>
    /// </summary>
    /// <param name="exception">The exception from which to build the error model</param>
    public static NotFoundErrorModel FromException(NotFoundException exception)
        => new(exception.Type.Name, exception.Id);
}
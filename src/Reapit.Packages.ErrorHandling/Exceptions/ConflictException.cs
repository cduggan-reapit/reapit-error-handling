using Reapit.Packages.ErrorHandling.Exceptions.Abstract;

namespace Reapit.Packages.ErrorHandling.Exceptions;

/// <summary>
/// Exception thrown when a precondition test failed
/// </summary>
/// <remarks>This is most commonly used in write requests when the user-provided entity tag does not match the current entity tag</remarks>
public class ConflictException : BaseEntityException
{
    /// <summary>
    /// The error message to be assigned to the underlying exception
    /// </summary>
    /// <remarks>This is internal to allow the UnitTests project to access it directly</remarks>
    internal const string ErrorMessage = "Precondition test failed";
    
    /// <summary>
    /// Initialize a new instance of the <see cref="ConflictException"/> class
    /// </summary>
    /// <param name="type">The type of the resource</param>
    /// <param name="entityIdentifier">The unique identifier of the resource</param>
    public ConflictException(Type type, string entityIdentifier)
        : base(ErrorMessage, type, entityIdentifier)
    {
    }
}
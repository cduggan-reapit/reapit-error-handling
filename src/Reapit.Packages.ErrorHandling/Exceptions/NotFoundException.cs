using Reapit.Packages.ErrorHandling.Exceptions.Abstract;

namespace Reapit.Packages.ErrorHandling.Exceptions;

/// <summary>
/// Exception thrown when a resource cannot be found
/// </summary>
public class NotFoundException : BaseEntityException
{
    /// <summary>
    /// The error message to be assigned to the underlying exception
    /// </summary>
    /// <remarks>This is internal to allow the UnitTests project to access it directly</remarks>
    internal const string ErrorMessage = "Precondition test failed";

    /// <summary>
    /// Initialize a new instance of the <see cref="NotFoundException"/> class
    /// </summary>
    /// <param name="type">The type of resource</param>
    /// <param name="entityIdentifier">The unique identifier of the resource</param>
    public NotFoundException(Type type, string entityIdentifier)
        : base(ErrorMessage, type, entityIdentifier)
    {
    }
}
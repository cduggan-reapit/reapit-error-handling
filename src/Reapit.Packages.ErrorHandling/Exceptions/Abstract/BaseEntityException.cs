using Reapit.Packages.ErrorHandling.Providers;

namespace Reapit.Packages.ErrorHandling.Exceptions.Abstract;

/// <summary>
/// Base class for exceptions raised for specific entities
/// </summary>
public abstract class BaseEntityException : ApplicationException 
{
    /// <summary>
    /// The type of resource for which the exception is raised
    /// </summary>
    public Type Type { get; }
    
    /// <summary>
    /// The unique identifier of the resource for which the exception is raised
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Initialize a new instance of the <see cref="BaseEntityException"/> class
    /// </summary>
    /// <param name="errorMessage">The message to assign to the exception</param>
    /// <param name="type">The type of the resource</param>
    /// <param name="entityIdentifier">The unique identifier of the resource</param>
    protected BaseEntityException(string errorMessage, Type type, string entityIdentifier)
        : base(errorMessage)
    {
        Id = entityIdentifier;
        Type = type;
    }
}
namespace Reapit.Packages.ErrorHandling.Providers;

/// <summary>
/// Ambient context to enable fixing DateTimeOffsets in test scenarios
/// </summary>
public class DateTimeOffsetProviderContext : IDisposable
{
    internal DateTimeOffset ContextDateTimeNow;
    
    private static readonly ThreadLocal<Stack<DateTimeOffsetProviderContext>> ThreadScopeStack = new(() => new Stack<DateTimeOffsetProviderContext>());
    
    /// <summary>
    /// Initialize a new instance of <see cref="DateTimeOffsetProviderContext"/>
    /// </summary>
    /// <param name="contextDateTimeNow">The fixed date time of the context</param>
    public DateTimeOffsetProviderContext(DateTimeOffset contextDateTimeNow)
    {
        ContextDateTimeNow = contextDateTimeNow;
        ThreadScopeStack.Value?.Push(this);
    }

    /// <summary>
    /// The current context.  Returns null when no context configured.
    /// </summary>
    public static DateTimeOffsetProviderContext? Current 
        => ThreadScopeStack.Value?.Count == 0 ? null : ThreadScopeStack.Value?.Peek();
    
    /// <inheritdoc />
    public void Dispose()
    {
        ThreadScopeStack.Value?.Pop();
        GC.SuppressFinalize(this);
    }
}
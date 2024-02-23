namespace Reapit.Packages.ErrorHandling.Providers;

/// <summary>
/// Provider for DateTimeOffsets accounting for ambient context
/// </summary>
public static class DateTimeOffsetProvider
{
    /// <summary>
    /// The current context DateTimeOffset
    /// </summary>
    public static DateTimeOffset Now
        => DateTimeOffsetProviderContext.Current == null
            ? DateTimeOffset.Now
            : DateTimeOffsetProviderContext.Current.ContextDateTimeNow;
}
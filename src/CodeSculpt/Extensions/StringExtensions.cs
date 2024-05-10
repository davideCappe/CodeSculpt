namespace CodeSculpt.Extensions;

/// <summary>
/// Contains extensions methods for the <see cref="string"/> type.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Determines whether two specified <see cref="string"/> objects have the same value, performing a case-insentive comparison.
    /// </summary>
    /// <param name="a">The first string to compare.</param>
    /// <param name="b">The second string to compare.</param>
    /// <returns><see langword="true"/> if the value of <paramref name="b"/> is the same as the value of <paramref name="b"/>, regardless the casing; otherwise, <see langword="false"/>. If both <paramref name="a"/> and <paramref name="b"/> are <see langword="null"/>, the method returns <see langword="true"/>.</returns>
    public static bool EqualsIgnoreCase(this string? a, string? b)
        => string.Equals(a, b, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="defaultValue"></param>
    /// <returns></returns>
    public static string? GetValueOrDefault(this string? input, string? defaultValue = default)
        => string.IsNullOrWhiteSpace(input) ? defaultValue : input;
}

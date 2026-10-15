using System;
using System.Collections.Generic;
using System.Globalization;

namespace Backend;

/// <summary>
/// A comparer for string values that compares numeric representations numerically
/// (e.g., "2" precedes "10") and text lexicographically in a case-insensitive manner.
/// </summary>
public class NaturalStringComparer : IComparer<string>
{
    /// <summary>
    /// Gets a shared default instance of <see cref="NaturalStringComparer"/>.
    /// </summary>
    public static NaturalStringComparer Default { get; } = new();

    /// <summary>
    /// Compares two strings using natural numeric-aware comparison.
    /// </summary>
    /// <param name="x">The first string to compare.</param>
    /// <param name="y">The second string to compare.</param>
    /// <returns>A signed number indicating the relative values of x and y.</returns>
    public int Compare(string? x, string? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (x is null) return -1;
        if (y is null) return 1;

        // Check if both strings are parseable numbers (integers or decimals)
        bool isNumX = decimal.TryParse(x, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal numX);
        bool isNumY = decimal.TryParse(y, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal numY);

        if (isNumX && isNumY)
        {
            return numX.CompareTo(numY);
        }

        // If one is numeric and the other is not, numbers precede text
        if (isNumX) return -1;
        if (isNumY) return 1;

        // Both are non-numeric strings: compare lexicographically
        return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
    }
}

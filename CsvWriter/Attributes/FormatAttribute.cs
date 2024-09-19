namespace CsvWriter.Attributes;

/// <summary>
/// Specifies the format for a property when writing to a CSV file.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class FormatAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FormatAttribute"/> class with the specified format.
    /// </summary>
    /// <param name="format">The format string.</param>
    public FormatAttribute(string format)
    {
        Format = format;
    }

    /// <summary>
    /// Gets the format string.
    /// </summary>
    public string Format { get; private set; }
}
namespace CsvWriter.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class FormatAttribute(string format) : Attribute
{
    public string Format { get; private set; } = format;
}
namespace CsvWriter.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NameAttribute(string name) : Attribute
    {
        public string Name { get; private set; } = name;
    }
}
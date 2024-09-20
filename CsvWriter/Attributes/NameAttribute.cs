using System;

namespace CsvWriter.Attributes
{
    /// <summary>
    /// Specifies the name of a property when writing to a CSV file.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameAttribute"/> class with the specified name.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        public NameAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string Name { get; private set; }
    }
}
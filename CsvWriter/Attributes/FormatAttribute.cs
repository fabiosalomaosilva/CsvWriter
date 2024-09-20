using CsvWriter.Configuration;
using System;

namespace CsvWriter.Attributes
{
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
        /// <param name="customFormat">The custom format</param>
        public FormatAttribute(FormatColumn format, string? customFormat = null)
        {
            Format = format;
            CustomFormat = customFormat;
        }

        /// <summary>
        /// Gets the format string.
        /// </summary>
        public FormatColumn Format { get; private set; }

        /// <summary>
        /// Gets the custom format.
        /// </summary>
        public string? CustomFormat { get; private set; }
    }
}
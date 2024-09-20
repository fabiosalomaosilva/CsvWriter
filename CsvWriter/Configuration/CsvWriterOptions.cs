using System.Globalization;
using System.Text;

namespace CsvWriter.Configuration
{
    /// <summary>
    /// Represents the options for the CsvWriter.
    /// </summary>
    public class CsvWriterOptions
    {
        /// <summary>
        /// Gets or sets the encoding used for writing the CSV file.
        /// </summary>
        public Encoding? Encoding { get; set; } = Encoding.UTF8;

        /// <summary>
        /// Gets or sets the delimiter used for separating values in the CSV file.
        /// </summary>
        public string? Delimiter { get; set; } = ";";

        /// <summary>
        /// Gets or sets the culture used for formatting values in the CSV file.
        /// </summary>
        public CultureInfo? CultureInfo { get; set; } = CultureInfo.InvariantCulture;
    }
}
using CsvWriter.Attributes;
using CsvWriter.Configuration;
using System.Linq;
using System.Reflection;

namespace CsvWriter.Utils
{
    internal static class Extensions
    {
        internal static string GetNameColumn(this PropertyInfo property)
        {
            var attribute = property.GetCustomAttributes(typeof(NameAttribute), false).FirstOrDefault();
            return attribute != null ? ((NameAttribute)attribute).Name : property.Name;
        }

        internal static string? GetFormatColumn(this PropertyInfo property)
        {
            var attribute = property.GetCustomAttributes(typeof(FormatAttribute), false).FirstOrDefault();
            if (attribute == null)
            {
                return FormatColumn.Default.GetFormat();
            }

            var format = ((FormatAttribute)attribute!).Format == null
                ? FormatColumn.Default
                : ((FormatAttribute)attribute!).Format;

            if (format == FormatColumn.Custom)
            {
                return ((FormatAttribute)attribute!)?.CustomFormat ?? FormatColumn.Default.GetFormat();
            }

            return format.GetFormat();
        }
    }
}
using CsvWriter.Attributes;
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
            return ((FormatAttribute)attribute!)?.Format;
        }
    }
}
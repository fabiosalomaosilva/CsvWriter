using CsvWriter.Configuration;
using CsvWriter.Utils;
using System.IO.Compression;
using System.Text;

namespace CsvWriter;

/// <summary>
/// Provides methods for creating CSV files.
/// </summary>
public class Writer
{
    /// <summary>
    /// Creates a CSV file as a memory stream.
    /// </summary>
    /// <typeparam name="T">The type of objects in the CSV file.</typeparam>
    /// <param name="objs">The collection of objects to write to the CSV file.</param>
    /// <param name="options">The options for writing the CSV file.</param>
    /// <returns>A memory stream containing the CSV file.</returns>
    public MemoryStream CreateFileAsMemoryStream<T>(IEnumerable<T> objs, CsvWriterOptions? options = null)
    {
        options ??= new CsvWriterOptions();

        var properties = typeof(T).GetProperties();
        var csv = new StringBuilder();
        foreach (var property in properties)
        {
            var nameColumn = property.GetNameColumn();
            csv.Append(nameColumn);
            csv.Append(options.Delimiter);
        }

        foreach (var obj in objs)
        {
            var prop = obj.GetType().GetProperties();
            csv.Append("\n");
            foreach (var property in prop)
            {
                var format = property.GetFormatColumn();
                var value = Convert.ToString(property.GetValue(obj), options.CultureInfo);
                csv.Append($"{value}:{format}");
                csv.Append(options.Delimiter);
            }
        }

        return new MemoryStream(options.Encoding.GetBytes(csv.ToString()));
    }

    /// <summary>
    /// Creates a compressed CSV file as a memory stream.
    /// </summary>
    /// <typeparam name="T">The type of objects in the CSV file.</typeparam>
    /// <param name="objs">The collection of objects to write to the CSV file.</param>
    /// <param name="name">The name of the compressed file.</param>
    /// <param name="options">The options for writing the CSV file.</param>
    /// <returns>A memory stream containing the compressed CSV file.</returns>
    public async Task<MemoryStream> CreateCompressedFileAsMemoryStream<T>(IEnumerable<T> objs, string name,
        CsvWriterOptions? options = null)
    {
        try
        {
            if (string.IsNullOrEmpty(name))
            {
                name = DateTime.Now.ToString("yyyyMMddHHmmss");
            }

            if (name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase) ||
                name.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                name = Path.GetFileNameWithoutExtension(name);
            }

            options ??= new CsvWriterOptions();

            var properties = typeof(T).GetProperties();
            var csv = new StringBuilder();
            foreach (var property in properties)
            {
                var nameColumn = property.GetNameColumn();
                csv.Append(nameColumn);
                csv.Append(options.Delimiter);
            }

            foreach (var obj in objs)
            {
                var props = obj?.GetType().GetProperties();
                csv.Append("\n");
                foreach (var property in props)
                {
                    var format = property.GetFormatColumn();

                    if (property.PropertyType == typeof(string))
                    {
                        var value = Convert.ToString(property.GetValue(obj), options.CultureInfo);
                        csv.Append(value);
                        csv.Append(options.Delimiter);
                        continue;
                    }

                    if (property.PropertyType == typeof(int))
                    {
                        var value = Convert.ToInt32(property.GetValue(obj), options.CultureInfo);
                        csv.Append(value);
                        csv.Append(options.Delimiter);
                        continue;
                    }

                    if (property.PropertyType == typeof(long))
                    {
                        var value = Convert.ToInt32(property.GetValue(obj), options.CultureInfo);
                        csv.Append(value);
                        csv.Append(options.Delimiter);
                        continue;
                    }

                    if (property.PropertyType == typeof(short))
                    {
                        var value = Convert.ToInt32(property.GetValue(obj), options.CultureInfo);
                        csv.Append(value);
                        csv.Append(options.Delimiter);
                        continue;
                    }

                    if (property.PropertyType == typeof(decimal))
                    {
                        var value = Convert.ToDecimal(property.GetValue(obj), options.CultureInfo);
                        csv.Append(value.ToString(format));
                        csv.Append(options.Delimiter);
                        continue;
                    }

                    if (property.PropertyType == typeof(DateTime))
                    {
                        var value = Convert.ToDateTime(property.GetValue(obj), options.CultureInfo);
                        csv.Append(value.ToString(format));
                        csv.Append(options.Delimiter);
                        continue;
                    }

                    if (property.PropertyType == typeof(bool))
                    {
                        var value = Convert.ToString(property.GetValue(obj), options.CultureInfo);
                        csv.Append(value);
                        csv.Append(options.Delimiter);
                        continue;
                    }

                    var valueFinal = Convert.ToString(property.GetValue(obj), options.CultureInfo);
                    csv.Append(valueFinal);
                    csv.Append(options.Delimiter);
                }
            }

            var memoryStream = new MemoryStream(options.Encoding.GetBytes(csv.ToString()));

            var compressedStream = new MemoryStream();
            using (var archive = new ZipArchive(compressedStream, ZipArchiveMode.Create, true))
            {
                var zipEntry = archive.CreateEntry(name + ".csv");
                await using var zipStream = zipEntry.Open();
                await memoryStream.CopyToAsync(zipStream);
            }

            compressedStream.Position = 0;
            return compressedStream;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
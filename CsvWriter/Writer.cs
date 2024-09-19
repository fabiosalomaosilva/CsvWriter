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
    /// Creates a MemoryStream containing the CSV data.
    /// </summary>
    /// <typeparam name="T">The type of objects in the collection.</typeparam>
    /// <param name="objs">The collection of objects to write to the CSV file.</param>
    /// <param name="encoding">The encoding to use for writing the CSV file. If not specified, UTF-8 encoding will be used.</param>
    /// <returns>A MemoryStream containing the CSV data.</returns>
    public MemoryStream CreateFileAsMemoryStream<T>(IEnumerable<T> objs, Encoding? encoding = null)
    {
        encoding ??= Encoding.UTF8;
        var properties = typeof(T).GetProperties();
        var csv = new StringBuilder();
        foreach (var property in properties)
        {
            var nameColumn = property.GetNameColumn();
            csv.Append(nameColumn);
            csv.Append(";");
        }

        foreach (var obj in objs)
        {
            var prop = obj.GetType().GetProperties();
            csv.Append("\n");
            foreach (var property in prop)
            {
                var value = Convert.ToString(property.GetValue(obj));
                csv.Append(value);
                csv.Append(";");
            }
        }

        return new MemoryStream(encoding.GetBytes(csv.ToString()));
    }

    /// <summary>
    /// Creates a compressed MemoryStream containing the CSV data.
    /// </summary>
    /// <typeparam name="T">The type of objects in the collection.</typeparam>
    /// <param name="objs">The collection of objects to write to the CSV file.</param>
    /// <param name="name">The name of the compressed file. If not specified, the current date and time will be used as the file name.</param>
    /// <param name="encoding">The encoding to use for writing the CSV file. If not specified, UTF-8 encoding will be used.</param>
    /// <returns>A compressed MemoryStream containing the CSV data.</returns>
    public async Task<MemoryStream> CreateCompressedFileAsMemoryStream<T>(IEnumerable<T> objs, string name,
        Encoding? encoding = null)
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

        encoding ??= Encoding.UTF8;
        var properties = typeof(T).GetProperties();
        var csv = new StringBuilder();
        foreach (var property in properties)
        {
            var nameColumn = property.GetNameColumn();
            csv.Append(nameColumn);
            csv.Append(";");
        }

        foreach (var obj in objs)
        {
            var prop = obj.GetType().GetProperties();
            csv.Append("\n");
            foreach (var property in prop)
            {
                var value = property.GetValue(obj);
                csv.Append(value);
                csv.Append(";");
            }
        }


        var memoryStream = new MemoryStream(encoding.GetBytes(csv.ToString()));

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
}
using CsvWriter.Utils;
using System.IO.Compression;
using System.Text;

namespace CsvWriter;

public class Writer
{
    public StreamWriter CreateAsStreamWriter<T>(IEnumerable<T> objs, Encoding? encoding = null)
    {
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

        var stream = new MemoryStream(encoding.GetBytes(csv.ToString()));
        return new StreamWriter(stream);
    }

    public MemoryStream Create<T>(IEnumerable<T> objs, Encoding? encoding = null)
    {
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

        return new MemoryStream(encoding.GetBytes(csv.ToString()));
    }

    public async Task<MemoryStream> CreateCompressed<T>(IEnumerable<T> objs, string name, Encoding? encoding = null)
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
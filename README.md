# CsvWriter
CsvWriter is a simple tool for writing data to CSV files.

## Features

- Write data in CSV format.
- Support for different delimiters.
- Support for different encodings.
- Support for ZIP compression.
- Support for formatting data.
- Easy to use and integrate into other projects.

## Installation

To use CsvWriter, you can install it directly from the NUGET Package Manager.
Here are some ways to install the package:

```bash
.NET CLI
dotnet add package CsvWriter

ou

Package Manager
NuGet\Install-Package CsvWriter

ou

PackageReference
<PackageReference Include="CsvWriter" Version="1.0.10" />

```

## Usage

Here is a basic example of how to use CsvWriter to create a CSV file in MemoryStream:

```csharp
public class Order
{
    [Name("ID")] 
    public string Id { get; set; }

    [Name("Date of Order")]
    [Format(FormatColumn.LongDate)]
    public DateTime Date { get; set; }

    [Name("Quantity")] 
    public int Quantity { get; set; }

    [Name("ID")]
    [Format(FormatColumn.Decimal)]
    public decimal Amount { get; set; }

    [Name("Total")]
    [Format(FormatColumn.Currency)]
    public decimal Total { get; set; }

    [Name("Customer")] 
    public string Customer { get; set; }

    [Name("IsShipping")] 
    public bool IsShipping { get; set; }
}
```


```csharp
using System;
using System.Collections.Generic;
using CsvWriterLib;

class Program
{
    static void Main()
    {
        var listaEmissores = new List<Order>
        {
            new Order
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                Quantity = 1,
                IsShipping = true,
                Amount = 100.00m,
                Total = 100.00m,
                Customer = "Customer 1"
            },
            new Order
            {
                Id = Guid.NewGuid().ToString(),
                IsShipping = true,
                Date = DateTime.Now,
                Quantity = 2,
                Amount = 200.00m,
                Total = 400.00m,
                Customer = "Customer 2"
            },
            new Order
            {
                Id = Guid.NewGuid().ToString(),
                IsShipping = false,
                Date = DateTime.Now,
                Quantity = 3,
                Amount = 300.00m,
                Total = 900.00m,
                Customer = "Customer 3"
            }
        };

        var options = new CsvWriterOptions
        {
            Delimiter = ";",
            CultureInfo = CultureInfo.GetCultureInfo("pt-BR"),
            Encoding = new UTF8Encoding(false)
        };

        var csvWriter = new Writer();
        MemoryStream csv = await csvWriter.CreateFileAsMemoryStream(listaEmissores, options);
    }
}
```

Here is a basic example of how to use CsvWriter to create a ZIP-compressed CSV file with output in MemoryStream:

```csharp
using System;
using System.Collections.Generic;
using CsvWriterLib;

class Program
{
    static void Main()
    {
        var listaEmissores = new List<Order>
        {   
            new Order
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                Quantity = 1,
                IsShipping = true,
                Amount = 100.00m,
                Total = 100.00m,
                Customer = "Customer 1"
            },
            new Order
            {
                Id = Guid.NewGuid().ToString(),
                IsShipping = true,
                Date = DateTime.Now,
                Quantity = 2,
                Amount = 200.00m,
                Total = 400.00m,
                Customer = "Customer 2"
            },
            new Order
            {
                Id = Guid.NewGuid().ToString(),
                IsShipping = false,
                Date = DateTime.Now,
                Quantity = 3,
                Amount = 300.00m,
                Total = 900.00m,
                Customer = "Customer 3"
            }
        };

        var options = new CsvWriterOptions
        {
            Delimiter = ";",
            CultureInfo = CultureInfo.GetCultureInfo("pt-BR"),
            Encoding = Encoding.UTF8
        };

        var name = "OrderReport";
        var csv = new Writer();
        MemoryStream relatorio = await csv.CreateCompressedFileAsMemoryStream(data, name, new UTF8Encoding(false));
    }
}
```

## Contribution

Contributions are welcome! Feel free to open issues and pull requests.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

CsvWriter is a simple tool for writing data to CSV files.

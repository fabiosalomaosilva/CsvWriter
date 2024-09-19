# CsvWriter
CsvWriter is a simple tool for writing data to CSV files.

## Features

- Write data in CSV format.
- Support for different delimiters.
- Easy to use and integrate into other projects.

## Installation

Para instalar o CsvWriter, você pode clonar o repositório diretamente do GitHub:

```bash
git clone https://github.com/seu-usuario/CsvWriter.git
```

## Usage

Here is a basic example of how to use CsvWriter to create a CSV file in MemoryStream:

```csharp
using System;
using System.Collections.Generic;
using CsvWriterLib;

class Program
{
    static void Main()
    {
        var data = new List<List<string>> {
            new List<string> { "Nome", "Idade", "Cidade" },
            new List<string> { "Alice", "30", "São Paulo" },
            new List<string> { "Bob", "25", "Rio de Janeiro" }
        };

        var csv = new Writer();
        MemoryStream relatorio = await csv.CreateFileAsMemoryStream(data, nome, new UTF8Encoding(false));
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
        var data = new List<List<string>> {
            new List<string> { "Nome", "Idade", "Cidade" },
            new List<string> { "Alice", "30", "São Paulo" },
            new List<string> { "Bob", "25", "Rio de Janeiro" }
        };

        var name = "RelatorioCliente";
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
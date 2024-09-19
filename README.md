# CsvWriter
CsvWriter é uma ferramenta simples para escrever dados em arquivos CSV.

## Funcionalidades

- Escrever dados em formato CSV.
- Suporte para diferentes delimitadores.
- Fácil de usar e integrar em outros projetos.

## Instalação

Para instalar o CsvWriter, você pode clonar o repositório diretamente do GitHub:

```bash
git clone https://github.com/seu-usuario/CsvWriter.git
```

## Uso

Aqui está um exemplo básico de como usar o CsvWriter para criar um arquivo CSV em MemoryStream:

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
        MemoryStream relatorio = await csv.Create(data, nome, new UTF8Encoding(false));
    }
}
```

Aqui está um exemplo básico de como usar o CsvWriter para criar um arquivo CSV em StreamWriter:

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
        StreamWriter relatorio = csv.CreateAsStreamWriter(data, new UTF8Encoding(false));
    }
}
```

Aqui está um exemplo básico de como usar o CsvWriter para criar um arquivo CSV com compressão ZIP com retorno em MemoryStream:

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
        MemoryStream relatorio = await csv.CreateCompressed(data, name, new UTF8Encoding(false));
    }
}
```

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
CsvWriter é uma ferramenta simples para escrever dados em arquivos CSV.

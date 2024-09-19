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

Aqui está um exemplo básico de como usar o CsvWriter em C#:

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

        using (var writer = new CsvWriter("output.csv"))
        {
            writer.Write(data);
        }
    }
}
```

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
CsvWriter é uma ferramenta simples para escrever dados em arquivos CSV.
using CsvWriter.Attributes;
using CsvWriter.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CsvWriter.POC
{
    public class Program
    {
        public static async Task Main()
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

            var csvWriter = new Writer();
            var csv = await csvWriter.CreateCompressedFileAsMemoryStream(listaEmissores, "CsvFileCompressed", options);

            await using var fileStream = new FileStream(
                $@"H:\Testes\TestesDocumentos\CsvFileCompressed-{DateTime.Now.Ticks}.zip",
                FileMode.Create, FileAccess.Write);
            csv.Seek(0, SeekOrigin.Begin);
            await csv.CopyToAsync(fileStream);
            fileStream.Close();
            await fileStream.DisposeAsync();
        }
    }

    public class Order
    {
        [Name("ID")] public string Id { get; set; }

        [Name("Date of Order")]
        [Format(FormatColumn.LongDate)]
        public DateTime Date { get; set; }

        [Name("Quantity")] public int Quantity { get; set; }

        [Name("ID")]
        [Format(FormatColumn.Decimal)]
        public decimal Amount { get; set; }

        [Name("Total")]
        [Format(FormatColumn.Currency)]
        public decimal Total { get; set; }

        [Name("Customer")] public string Customer { get; set; }

        [Name("IsShipping")] public bool IsShipping { get; set; }
    }
}
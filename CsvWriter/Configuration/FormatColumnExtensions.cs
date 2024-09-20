using CsvWriter.Configuration;
using System;

namespace CsvWriter
{
    public static class FormatColumnExtensions
    {
        public static string GetFormat(this FormatColumn format)
        {
            return format switch
            {
                FormatColumn.Default => string.Empty,
                FormatColumn.Decimal => "N2",
                FormatColumn.ShortDate => "d",
                FormatColumn.LongDate => "D",
                FormatColumn.ShortTime => "t",
                FormatColumn.LongTime => "T",
                FormatColumn.ShortDateTime => "g",
                FormatColumn.LongDateTime => "G",
                FormatColumn.Currency => "C",
                FormatColumn.Percentage => "P",
                FormatColumn.Scientific => "E",
                FormatColumn.GeneralNumber => "G",
                FormatColumn.Custom => string.Empty,
                _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
            };
        }
    }
}
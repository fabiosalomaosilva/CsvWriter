namespace CsvWriter.Configuration;

public enum FormatColumn
{
    /// <summary>
    /// The default format.
    /// </summary>
    Default,

    /// <summary>
    /// The decimal number format.
    /// </summary>
    Decimal,

    /// <summary>
    /// The short date format.
    /// </summary>
    ShortDate,

    /// <summary>
    /// The long date format.
    /// </summary>
    LongDate,

    /// <summary>
    /// The short time format.
    /// </summary>
    ShortTime,

    /// <summary>
    /// The long time format.
    /// </summary>
    LongTime,

    /// <summary>
    /// The short date and time format.
    /// </summary>
    ShortDateTime,

    /// <summary>
    /// The long date and time format.
    /// </summary>
    LongDateTime,

    /// <summary>
    /// The currency format.
    /// </summary>
    Currency,

    /// <summary>
    /// The percentage format.
    /// </summary>
    Percentage,

    /// <summary>
    /// The scientific format.
    /// </summary>
    Scientific,

    /// <summary>
    /// The general number format.
    /// </summary>
    GeneralNumber,

    /// <summary>
    /// The custom format.
    /// </summary>
    Custom
}
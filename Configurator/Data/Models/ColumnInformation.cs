namespace Configurator.Data.Models;

public class ColumnInformation
{
    public ColumnInformation(string columnName, int ordinalPosition, bool isNullable, string dataType,
        int? maximumLength, int? numericPrecision, int? numericScale)
    {
        ColumnName = columnName;
        OrdinalPosition = ordinalPosition;
        IsNullable = isNullable;
        DataType = dataType;
        MaximumLength = maximumLength;
        NumericPrecision = numericPrecision;
        NumericScale = numericScale;
    }

    public string ColumnName { get; set; }
    public int OrdinalPosition { get; set; }
    public bool IsNullable { get; set; }
    public string DataType { get; set; }
    public int? MaximumLength { get; set; }
    public int? NumericPrecision { get; set; }
    public int? NumericScale { get; set; }
}
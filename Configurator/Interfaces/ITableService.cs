namespace Configurator.Interfaces;

public interface ITableService
{
    Task<IEnumerable<string>> GetTableColumns(string tableName);
    Task<Dictionary<int, List<string>>> GetTableData(string tableName, IEnumerable<string> columns);
}
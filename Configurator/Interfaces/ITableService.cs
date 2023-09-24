namespace Configurator.Interfaces;

public interface ITableService
{
    Task<IEnumerable<string>> GetTableColumns(string tableName);
    Task<List<Dictionary<string, string>>> GetTableData(string tableName, List<string> columns);
    Task<string> GetPrimaryKeyColumns(string tableName);
}
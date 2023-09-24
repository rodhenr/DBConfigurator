using Configurator.Data.Models;

namespace Configurator.Interfaces;

public interface ITableService
{
    Task<IEnumerable<string>> GetTableColumns(string tableName);
    Task<List<Dictionary<string, string>>> GetTableData(string tableName, List<string> columns);
    Task<string> GetPrimaryKeyColumns(string tableName);
    Task<List<ColumnInformation>> GetTableInformationSchema(string tableName);
    Task InsertIntoDatabaseAsync(Dictionary<string, string> data, string tableName);
}
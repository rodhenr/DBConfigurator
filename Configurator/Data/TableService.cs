using Configurator.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Configurator.Data;

public class TableService : ITableService
{
    private readonly ApplicationDbContext _context;

    public TableService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<string>> GetTableColumns(string tableName)
    {
        return await _context.Database
            .SqlQuery<string>($"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = {tableName}")
            .ToListAsync();
    }

    public async Task<List<Dictionary<string, string>>> GetTableData(string tableName, List<string> columns)
    {
        var dataList = new List<Dictionary<string, string>>();
        var connString = _context.Database.GetConnectionString();

        await using var connection = new SqlConnection(connString);
        await connection.OpenAsync();

        var command = new SqlCommand($"SELECT * FROM {tableName}", connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var columnValues = columns.ToDictionary(column => column, column => reader[column].ToString() ?? "");
            dataList.Add(columnValues);
        }

        return dataList;
    }

    public async Task<string> GetPrimaryKeyColumns(string tableName)
    {
        var connString = _context.Database.GetConnectionString();

        await using var connection = new SqlConnection(connString);
        await connection.OpenAsync();

        const string query = """
                             SELECT STRING_AGG(COLUMN_NAME, ', ') AS PrimaryKeyColumns
                             FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                             WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1
                             AND TABLE_NAME = 'Packages';
                             """;

        var command = new SqlCommand(query, connection);
        await using var reader = await command.ExecuteReaderAsync();

        await reader.ReadAsync();
        return reader.GetString(0);
    }
}
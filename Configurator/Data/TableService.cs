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

    public async Task<Dictionary<int, List<string>>> GetTableData(string tableName, IEnumerable<string> columns)
    {
        var data = new Dictionary<int, List<string>>();
        var connString = _context.Database.GetConnectionString();

        await using var connection = new SqlConnection(connString);
        await connection.OpenAsync();

        var command = new SqlCommand($"SELECT * FROM {tableName}", connection);
        await using var reader = await command.ExecuteReaderAsync();

        var rowCount = 1;
        while (await reader.ReadAsync())
        {
            var list = new List<string?>();

            foreach (var column in columns)
            {
                list.Add(reader[column].ToString());
            }

            data.Add(rowCount, list);
            rowCount++;
        }

        return data;
    }
}
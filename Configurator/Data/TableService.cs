using Configurator.Data.Models;
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

    public async Task<List<string>> GetPrimaryKeyColumns(string tableName)
    {
        var columns = new List<string>();
        var connString = _context.Database.GetConnectionString();

        await using var connection = new SqlConnection(connString);
        await connection.OpenAsync();

        var query =
            $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1 AND TABLE_NAME = '{tableName}'";

        var command = new SqlCommand(query, connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            columns.Add(reader.GetString(0));
        }

        return columns;
    }

    public async Task<List<ColumnInformation>> GetTableInformationSchema(string tableName)
    {
        var result = new List<ColumnInformation>();
        var connString = _context.Database.GetConnectionString();

        await using var connection = new SqlConnection(connString);
        await connection.OpenAsync();

        var query = $"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

        var command = new SqlCommand(query, connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var columnName = reader["COLUMN_NAME"].ToString()!;
            var ordinalPosition = int.Parse(reader["ORDINAL_POSITION"].ToString()!);
            var isNullable = reader["IS_NULLABLE"].ToString() == "YES";
            var dataType = reader["DATA_TYPE"].ToString()!;
            int? maximumLength = reader["CHARACTER_MAXIMUM_LENGTH"].ToString() == ""
                ? null
                : int.Parse(reader["CHARACTER_MAXIMUM_LENGTH"].ToString()!);
            int? numericPrecision = reader["NUMERIC_PRECISION"].ToString() == ""
                ? null
                : int.Parse(reader["NUMERIC_PRECISION"].ToString()!);
            int? numericScale = reader["NUMERIC_SCALE"].ToString() == ""
                ? null
                : int.Parse(reader["NUMERIC_SCALE"].ToString()!);

            var columnInformation = new ColumnInformation(columnName!, ordinalPosition, isNullable, dataType,
                maximumLength, numericPrecision, numericScale);

            result.Add(columnInformation);
        }

        return result;
    }

    public async Task InsertIntoDatabaseAsync(Dictionary<string, string> data, string tableName)
    {
        var connString = _context.Database.GetConnectionString();

        await using var connection = new SqlConnection(connString);
        await connection.OpenAsync();

        var columns = string.Join(", ", data.Keys);
        var values = string.Join(", ", data.Keys.Select(key => $"@{key}"));
        var query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

        var command = new SqlCommand(query, connection);

        foreach (var item in data)
        {
            command.Parameters.AddWithValue($"@{item.Key}", item.Value);
        }

        await command.ExecuteNonQueryAsync();
    }

    public async Task DeleteAsync(Dictionary<string, string> data, string tableName)
    {
        var connString = _context.Database.GetConnectionString();

        await using var connection = new SqlConnection(connString);
        await connection.OpenAsync();

        var whereQuery = data.Select(d => $"{d.Key} = '{d.Value}'");
        var query = $"DELETE FROM {tableName} WHERE {string.Join(" AND ", whereQuery)}";

        var command = new SqlCommand(query, connection);

        await command.ExecuteNonQueryAsync();
    }
}
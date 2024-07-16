using Dapper;
using Microsoft.Extensions.Configuration;
using MyBookApp.Core.Models;
using MyBookApp.DataAccess.Interfaces;
using Npgsql;

namespace MyBookApp.DataAccess.Repositories;

public class PublisherRepository : IPublisherRepository
{
    private readonly string _dbConnection;
    public PublisherRepository(IConfiguration configuration)
    {
        _dbConnection = configuration.GetConnectionString("DatabaseConnection");
    }

    public async Task<int> AddPublisherAsync(Publisher publisher)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        var sql = @"INSERT INTO ""Publishers"" (""Name"")
                    VALUES (@Name)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, publisher);
        await connection.CloseAsync();

        return id;
    }

    public async Task DeletePublisherAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"DELETE FROM ""Publishers"" WHERE ""Id"" = @Id;";
        
        await connection.ExecuteAsync(sql, new { Id = id });
        await connection.CloseAsync();
    }

    public async Task<Publisher> GetPublisherAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT * FROM ""Publishers""
                    WHERE ""Id"" = @Id;";

        var publisher = await connection.QuerySingleOrDefaultAsync<Publisher>(sql, new { Id = id });
        await connection.CloseAsync();

        return publisher;
    }

    public async Task UpdatePublisherAsync(int id, Publisher publisher)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"UPDATE ""Publishers""
                    SET
                        ""Name"" = CASE WHEN @Name IS NULL THEN ""Name"" ELSE @Name END
                    WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id, publisher.Name});
        await connection.CloseAsync();
    }

    public async Task<bool> PublisherExistsAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT count(1) FROM ""Publishers"" WHERE ""Id"" = @Id;";

        var exists = await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
        await connection.CloseAsync();

        return exists;
    }
}
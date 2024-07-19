using Dapper;
using Microsoft.Extensions.Configuration;
using MyBookApp.Core.Models;
using MyBookApp.DataAccess.Interfaces;
using Npgsql;

namespace MyBookApp.DataAccess.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly string _dbConnection;
    public AuthorRepository(IConfiguration configuration)
    {
        _dbConnection = configuration.GetConnectionString("DatabaseConnection");
    }
    public async Task<int> AddAuthorAsync(Author author)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        var sql = @"INSERT INTO ""Authors"" (""FullName"",""DateOfBirth"")
                    VALUES (@FullName,@DateOfBirth)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, new {FullName = author.FullName,DateOfBirth = author.DateOfBirth.Date});
        await connection.CloseAsync();

        return id;
    }

    public async Task DeleteAuthorAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"DELETE FROM ""Authors"" WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id });
        await connection.CloseAsync();
    }

    public async Task<Author> GetAuthorAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT * FROM ""Authors""
                    WHERE ""Id"" = @Id;";

        var author = await connection.QuerySingleOrDefaultAsync<Author>(sql, new { Id = id });
        await connection.CloseAsync();

        return author;
    }

    public async Task UpdateAuthorAsync(int id, Author author)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"UPDATE ""Authors""
                    SET
                        ""FullName"" = CASE WHEN @FullName IS NULL THEN ""FullName"" ELSE @FullName END,
                        ""DateOfBirth"" = CASE WHEN @DateOfBirth IS NULL THEN ""DateOfBirth"" ELSE @DateOfBirth END
                    WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id, author.FullName, author.DateOfBirth });
        await connection.CloseAsync();
    }

    public async Task<bool> AuthorExistsAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT count(1) FROM ""Authors"" WHERE ""Id"" = @Id;";

        var exists = await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
        await connection.CloseAsync();

        return exists;
    }
}
using Dapper;
using Microsoft.Extensions.Configuration;
using MyBookApp.Core.Models;
using MyBookApp.DataAccess.Interfaces;
using MyBookApp.DataAccess.SqlScripts;
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
        var id = await connection.ExecuteScalarAsync<int>(Sql.AddAuthor, new {FullName = author.FullName,DateOfBirth = author.DateOfBirth.Date});
        await connection.CloseAsync();

        return id;
    }

    public async Task DeleteAuthorAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        await connection.ExecuteAsync(Sql.DeleteAuthor, new { Id = id });
        await connection.CloseAsync();
    }

    public async Task<Author> GetAuthorAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        var author = await connection.QuerySingleOrDefaultAsync<Author>(Sql.GetAuthor, new { Id = id });
        await connection.CloseAsync();

        return author;
    }

    public async Task UpdateAuthorAsync(int id, Author author)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        await connection.ExecuteAsync(Sql.UpdateAuthor, new { Id = id, author.FullName, author.DateOfBirth });
        await connection.CloseAsync();
    }

    public async Task<bool> AuthorExistsAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        var exists = await connection.ExecuteScalarAsync<bool>(Sql.ExistsAuthor, new { Id = id });
        await connection.CloseAsync();

        return exists;
    }
}
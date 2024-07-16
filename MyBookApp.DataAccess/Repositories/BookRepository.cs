using Dapper;
using Microsoft.Extensions.Configuration;
using MyBookApp.Core.Models;
using MyBookApp.DataAccess.Interfaces;
using Npgsql;

namespace MyBookApp.DataAccess.Repositories;

public class BookRepository : IBookRepository
{
    private readonly string _dbConnection;
    public BookRepository(IConfiguration configuration)
    {
        _dbConnection = configuration.GetConnectionString("DatabaseConnection");
    }

    public async Task<int> AddBookAsync(Book book)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        var sql = @"INSERT INTO ""Books"" (""Name"",""Description"",""AuthorId"",""PublisherId"")
                    VALUES (@Name,@Description,@AuthorId,@PublisherId)
                    RETURNING ""Id"";";

        var id = await connection.ExecuteScalarAsync<int>(sql, book);
        await connection.CloseAsync();

        return id;
    }

    public async Task DeleteBookAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"DELETE FROM ""Books"" WHERE ""Id"" = @Id;";
        
        await connection.ExecuteAsync(sql, new { Id = id });
        await connection.CloseAsync();
    }

    public async Task<Book> GetBookAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT * FROM ""Books""
                    WHERE ""Id"" = @Id;";

        var book = await connection.QuerySingleOrDefaultAsync<Book>(sql, new { Id = id });
        await connection.CloseAsync();

        return book;
    }

    public async Task UpdateBookAsync(int id, Book book)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"UPDATE ""Books""
                    SET
                        ""Name"" = CASE WHEN @Name IS NULL THEN ""Name"" ELSE @Name END,
                        ""Description"" = CASE WHEN @Description IS NULL THEN ""Description"" ELSE @Description END,
                        ""AuthorId"" = CASE WHEN @AuthorId IS NULL THEN ""AuthorId"" ELSE @AuthorId END,
                        ""PublisherId"" = CASE WHEN @PublisherId = 0 THEN ""PublisherId"" ELSE @PublisherId END
                    WHERE ""Id"" = @Id;";

        await connection.ExecuteAsync(sql, new { Id = id, book.Name,book.Description,book.AuthorId,book.PublisherId});
        await connection.CloseAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT * FROM ""Books""
                    WHERE ""AuthorId"" = @AuthorId;";

        var books = await connection.QueryAsync<Book>(sql, new { AuthorId = authorId });
        await connection.CloseAsync();

        return books;
    }

    public async Task<IEnumerable<Book>> GetBooksByPublisherIdAsync(int publisherId)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT * FROM ""Books""
                    WHERE ""PublisherId"" = @PublisherId;";

        var books = await connection.QueryAsync<Book>(sql, new { PublisherId = publisherId });
        await connection.CloseAsync();

        return books;
    }

    public async Task<bool> BookExistsAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);

        var sql = @"SELECT count(1) FROM ""Books"" WHERE ""Id"" = @Id;";

        var exists = await connection.ExecuteScalarAsync<bool>(sql, new { Id = id });
        await connection.CloseAsync();

        return exists;
    }
}
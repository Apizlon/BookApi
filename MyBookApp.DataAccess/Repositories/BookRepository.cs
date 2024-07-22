using Dapper;
using Microsoft.Extensions.Configuration;
using MyBookApp.Core.Models;
using MyBookApp.DataAccess.Interfaces;
using MyBookApp.DataAccess.SqlScripts;
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
        var id = await connection.ExecuteScalarAsync<int>(Sql.AddBook, book);
        await connection.CloseAsync();

        return id;
    }

    public async Task DeleteBookAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        await connection.ExecuteAsync(Sql.DeleteBook, new { Id = id });
        await connection.CloseAsync();
    }

    public async Task<Book> GetBookAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        var book = await connection.QuerySingleOrDefaultAsync<Book>(Sql.GetBook, new { Id = id });
        await connection.CloseAsync();

        return book;
    }

    public async Task UpdateBookAsync(int id, Book book)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        await connection.ExecuteAsync(Sql.UpdateBook, new { Id = id, book.Name,book.Description,book.AuthorId,book.PublisherId});
        await connection.CloseAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        var books = await connection.QueryAsync<Book>(Sql.GetBooksByAuthorId, new { AuthorId = authorId });
        await connection.CloseAsync();

        return books;
    }

    public async Task<IEnumerable<Book>> GetBooksByPublisherIdAsync(int publisherId)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        var books = await connection.QueryAsync<Book>(Sql.GetBooksByPublisherId, new { PublisherId = publisherId });
        await connection.CloseAsync();

        return books;
    }

    public async Task<bool> BookExistsAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        var exists = await connection.ExecuteScalarAsync<bool>(Sql.ExistsBook, new { Id = id });
        await connection.CloseAsync();

        return exists;
    }
}
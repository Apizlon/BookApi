using System.Data.Common;
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
    
    private async Task<DbConnection> CreateConnectionAsync()
    {
        var connection = new NpgsqlConnection(_dbConnection);
        await connection.OpenAsync();
        return connection;
    }

    public async Task<int> AddBookAsync(Book book)
    {
        await using var connection = await CreateConnectionAsync();
        var id = await connection.ExecuteScalarAsync<int>(Sql.AddBook, book);

        return id;
    }

    public async Task DeleteBookAsync(int id)
    {
        await using var connection = await CreateConnectionAsync();
        await connection.ExecuteAsync(Sql.DeleteBook, new { Id = id });
    }

    public async Task<Book> GetBookAsync(int id)
    {
        await using var connection = await CreateConnectionAsync();
        var book = await connection.QuerySingleOrDefaultAsync<Book>(Sql.GetBook, new { Id = id });

        return book;
    }

    public async Task UpdateBookAsync(int id, Book book)
    {
        await using var connection = await CreateConnectionAsync();
        await connection.ExecuteAsync(Sql.UpdateBook, new { Id = id, book.Name,book.Description,book.AuthorId,book.PublisherId});
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
    {
        await using var connection = await CreateConnectionAsync();
        var books = await connection.QueryAsync<Book>(Sql.GetBooksByAuthorId, new { AuthorId = authorId });

        return books;
    }

    public async Task<IEnumerable<Book>> GetBooksByPublisherIdAsync(int publisherId)
    {
        await using var connection = await CreateConnectionAsync();
        var books = await connection.QueryAsync<Book>(Sql.GetBooksByPublisherId, new { PublisherId = publisherId });

        return books;
    }

    public async Task<bool> BookExistsAsync(int id)
    {
        await using var connection = await CreateConnectionAsync();
        var exists = await connection.ExecuteScalarAsync<bool>(Sql.ExistsBook, new { Id = id });

        return exists;
    }
}
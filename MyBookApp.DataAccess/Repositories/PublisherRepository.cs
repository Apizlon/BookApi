using Dapper;
using Microsoft.Extensions.Configuration;
using MyBookApp.Core.Models;
using MyBookApp.DataAccess.Interfaces;
using MyBookApp.DataAccess.SqlScripts;
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
        var id = await connection.ExecuteScalarAsync<int>(Sql.AddPublisher, publisher);
        await connection.CloseAsync();
        
        return id;
    }

    public async Task DeletePublisherAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        await connection.ExecuteAsync(Sql.DeletePublisher, new { Id = id });
        await connection.CloseAsync();
    }

    public async Task<Publisher> GetPublisherAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        var publisher = await connection.QuerySingleOrDefaultAsync<Publisher>(Sql.GetPublisher, new { Id = id });
        await connection.CloseAsync();

        return publisher;
    }

    public async Task UpdatePublisherAsync(int id, Publisher publisher)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        await connection.ExecuteAsync(Sql.UpdatePublisher, new { Id = id, publisher.Name});
        await connection.CloseAsync();
    }

    public async Task<bool> PublisherExistsAsync(int id)
    {
        await using var connection = new NpgsqlConnection(_dbConnection);
        var exists = await connection.ExecuteScalarAsync<bool>(Sql.ExistsPublisher, new { Id = id });
        await connection.CloseAsync();

        return exists;
    }
}
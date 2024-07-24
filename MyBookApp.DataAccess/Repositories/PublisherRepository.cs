using System.Data.Common;
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
    
    private async Task<DbConnection> CreateConnectionAsync()
    {
        var connection = new NpgsqlConnection(_dbConnection);
        await connection.OpenAsync();
        return connection;
    }
    
    public async Task<int> AddPublisherAsync(Publisher publisher)
    {
        await using var connection = await CreateConnectionAsync();
        var id = await connection.ExecuteScalarAsync<int>(Sql.AddPublisher, publisher);
        
        return id;
    }

    public async Task DeletePublisherAsync(int id)
    {
        await using var connection = await CreateConnectionAsync();
        await connection.ExecuteAsync(Sql.DeletePublisher, new { Id = id });
    }

    public async Task<Publisher> GetPublisherAsync(int id)
    {
        await using var connection = await CreateConnectionAsync();
        var publisher = await connection.QuerySingleOrDefaultAsync<Publisher>(Sql.GetPublisher, new { Id = id });

        return publisher;
    }

    public async Task UpdatePublisherAsync(int id, Publisher publisher)
    {
        await using var connection = await CreateConnectionAsync();
        await connection.ExecuteAsync(Sql.UpdatePublisher, new { Id = id, publisher.Name});
    }

    public async Task<bool> PublisherExistsAsync(int id)
    {
        await using var connection = await CreateConnectionAsync();
        var exists = await connection.ExecuteScalarAsync<bool>(Sql.ExistsPublisher, new { Id = id });

        return exists;
    }
}
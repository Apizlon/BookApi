using MyBookApp.Core.Models;

namespace MyBookApp.DataAccess.Interfaces;

public interface IPublisherRepository
{
    Task<int> AddPublisherAsync(Publisher publisher);
    Task DeletePublisherAsync(int id);
    Task<Publisher> GetPublisherAsync(int id);
    Task UpdatePublisherAsync(int id,Publisher publisher);
    Task<bool> PublisherExistsAsync(int id);
}
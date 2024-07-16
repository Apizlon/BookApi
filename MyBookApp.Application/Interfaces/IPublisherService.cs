using MyBookApp.Application.Contracts;

namespace MyBookApp.Application.Interfaces;

public interface IPublisherService
{
    Task<int> AddPublisherAsync(PublisherRequest publisherRequest);
    Task DeletePublisherAsync(int id);
    Task<PublisherResponse> GetPublisherAsync(int id);
    Task UpdatePublisherAsync(int id, PublisherRequest publisherRequest);
    Task<bool> PublisherExistsAsync(int id);
}
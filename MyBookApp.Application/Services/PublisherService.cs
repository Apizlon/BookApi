using MyBookApp.Application.Contracts;
using MyBookApp.Application.Interfaces;
using MyBookApp.Application.Mappers;
using MyBookApp.Application.Validators;
using MyBookApp.Core.Exceptions;
using MyBookApp.DataAccess.Interfaces;

namespace MyBookApp.Application.Services;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;
    public PublisherService(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public async Task<int> AddPublisherAsync(PublisherRequest publisherRequest)
    {
        publisherRequest.AddValidation();
        return await _publisherRepository.AddPublisherAsync(publisherRequest.MapToCore());
    }

    public async Task DeletePublisherAsync(int id)
    {
        var isPublisherExists = await PublisherExistsAsync(id);
        if (!isPublisherExists)
        {
            throw new PublisherNotFoundException(id);
        }
        await _publisherRepository.DeletePublisherAsync(id);
    }

    public async Task<PublisherResponse> GetPublisherAsync(int id)
    {
        var isAuthorExists = await PublisherExistsAsync(id);
        if (!isAuthorExists)
        {
            throw new PublisherNotFoundException(id);
        }
        var publisher = await _publisherRepository.GetPublisherAsync(id);
        return publisher.MapToContract();
    }

    public async Task UpdatePublisherAsync(int id, PublisherRequest publisherRequest)
    {
        var isPublisherExists = await PublisherExistsAsync(id);
        publisherRequest.UpdateValidation(id,isPublisherExists);
        await _publisherRepository.UpdatePublisherAsync(id, publisherRequest.MapToCore());
    }

    public async Task<bool> PublisherExistsAsync(int id)
    {
        return await _publisherRepository.PublisherExistsAsync(id);
    }
}
using MyBookApp.Application.Contracts;
using MyBookApp.Core.Models;

namespace MyBookApp.Application.Mappers;

public static class PublisherMapper
{
    public static Publisher MapToCore(this PublisherRequest request)
    {
        return new Publisher
        {
            Name = request.Name
        };
    }

    public static PublisherResponse MapToContract(this Publisher publisher)
    {
        return new PublisherResponse
        {
            Id = publisher.Id,
            Name = publisher.Name
        };
    }
}
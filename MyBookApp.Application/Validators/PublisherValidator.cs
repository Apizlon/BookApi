using Microsoft.IdentityModel.Tokens;
using MyBookApp.Application.Contracts;
using MyBookApp.Core.Exceptions;

namespace MyBookApp.Application.Validators;

public static class PublisherValidator
{
    public static void AddValidation(this PublisherRequest publisherRequest)
    {
        if (string.IsNullOrEmpty(publisherRequest.Name) || publisherRequest.Name.Length>50)
        {
            throw new ValidationException("Имя должно быть непустым, длиной до 50 символов");
        }
    }

    public static void UpdateValidation(this PublisherRequest publisherRequest,int id,bool isPublisherExists)
    {
        if (!isPublisherExists)
        {
            throw new PublisherNotFoundException(id);
        }
        publisherRequest.AddValidation();
    }
}
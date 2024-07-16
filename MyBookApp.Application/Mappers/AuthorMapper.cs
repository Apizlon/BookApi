using MyBookApp.Application.Contracts;
using MyBookApp.Core.Models;

namespace MyBookApp.Application.Mappers;

public static class AuthorMapper
{
    public static Author MapToCore(this AuthorRequest request)
    {
        return new Author
        {
            FullName = request.FullName,
            DateOfBirth = request.DateOfBirth
        };
    }

    public static AuthorResponse MapToContract(this Author author)
    {
        return new AuthorResponse
        {
            Id = author.Id,
            FullName = author.FullName,
            DateOfBirth = author.DateOfBirth
        };
    }
}
using MyBookApp.Application.Contracts;
using MyBookApp.Core.Models;

namespace MyBookApp.Application.Mappers;

public static class BookMapper
{
    public static Book MapToCore(this BookRequest request)
    {
        return new Book
        {
            Name = request.Name,
            Description = request.Description,
            AuthorId = request.AuthorId,
            PublisherId = request.PublisherId
        };
    }

    public static BookResponse MapToContract(this Book book)
    {
        return new BookResponse(book.Id,book.Name,book.Description,book.AuthorId,book.PublisherId);
    }
}
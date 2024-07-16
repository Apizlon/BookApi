namespace MyBookApp.Application.Contracts;

public record BookResponse(
    int Id,
    string Name,
    string Description,
    int AuthorId,
    int PublisherId);
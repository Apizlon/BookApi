namespace MyBookApp.Application.Contracts;

public record BookRequest(
    string Name,
    string Description,
    int AuthorId,
    int PublisherId);
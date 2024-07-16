namespace MyBookApp.Application.Contracts;

public record AuthorResponse(
    int Id,
    string FullName,
    string DateOfBirth);
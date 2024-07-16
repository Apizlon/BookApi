namespace MyBookApp.Application.Contracts;

public record AuthorRequest(
    string FullName,
    string DateOfBirth);
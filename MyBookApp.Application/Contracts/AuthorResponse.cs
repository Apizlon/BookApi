namespace MyBookApp.Application.Contracts;

public class AuthorResponse
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
}
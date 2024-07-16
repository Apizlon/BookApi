namespace MyBookApp.Application.Contracts;

public class BookRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
}
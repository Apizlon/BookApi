namespace MyBookApp.Application.Contracts;

public class BookResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
}
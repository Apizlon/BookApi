namespace MyBookApp.Core.Models;

/// <summary>
/// Класс сущности Автор
/// </summary>
public class Author
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
}
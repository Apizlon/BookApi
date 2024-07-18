namespace MyBookApp.Core.Exceptions;

public class BookNotFoundException : NotFoundException
{
    public BookNotFoundException(int id) : base($"Книга с id {id} не найдена.")
    {
        
    }
}
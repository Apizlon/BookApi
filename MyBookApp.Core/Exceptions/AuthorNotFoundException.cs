namespace MyBookApp.Core.Exceptions;

public class AuthorNotFoundException : NotFoundException
{
    public AuthorNotFoundException(int id) : base($"Автор с id {id} не найден.")
    {
        
    }
}
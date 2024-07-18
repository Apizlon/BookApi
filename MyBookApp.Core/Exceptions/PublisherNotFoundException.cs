namespace MyBookApp.Core.Exceptions;

public class PublisherNotFoundException : NotFoundException
{
    public PublisherNotFoundException(int id) : base("Издатель с id {id} не найден.")
    {
        
    }
}
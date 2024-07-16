using MyBookApp.Core.Models;

namespace MyBookApp.DataAccess.Interfaces;

public interface IBookRepository
{
    Task<int> AddBookAsync(Book book);
    Task DeleteBookAsync(int id);
    Task<Book> GetBookAsync(int id);
    Task UpdateBookAsync(int id,Book book);
    Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId);
    Task<IEnumerable<Book>> GetBooksByPublisherIdAsync(int publisherId);
    Task<bool> BookExistsAsync(int id);
}
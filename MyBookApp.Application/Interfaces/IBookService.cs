using MyBookApp.Application.Contracts;

namespace MyBookApp.Application.Interfaces;

public interface IBookService
{
    Task<int> AddBookAsync(BookRequest bookRequest);
    Task DeleteBookAsync(int id);
    Task<BookResponse> GetBookAsync(int id);
    Task UpdateBookAsync(int id, BookRequest bookRequest);
    Task<IEnumerable<BookResponse>> GetBooksByAuthorIdAsync(int authorId);
    Task<IEnumerable<BookResponse>> GetBooksByPublisherIdAsync(int authorId);
    Task<bool> BookExistsAsync(int id);
}
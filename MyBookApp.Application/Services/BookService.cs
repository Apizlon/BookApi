using MyBookApp.Application.Contracts;
using MyBookApp.Application.Interfaces;
using MyBookApp.Application.Mappers;
using MyBookApp.Core.Models;
using MyBookApp.DataAccess.Interfaces;

namespace MyBookApp.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<int> AddBookAsync(BookRequest bookRequest)
    {
        return await _bookRepository.AddBookAsync(bookRequest.MapToCore());
    }

    public async Task DeleteBookAsync(int id)
    {
        await _bookRepository.DeleteBookAsync(id);
    }

    public async Task<BookResponse> GetBookAsync(int id)
    {
        var book = await _bookRepository.GetBookAsync(id);
        return book.MapToContract();
    }

    public async Task UpdateBookAsync(int id, BookRequest bookRequest)
    {
        await _bookRepository.UpdateBookAsync(id, bookRequest.MapToCore());
    }

    public async Task<IEnumerable<BookResponse>> GetBooksByAuthorIdAsync(int authorId)
    {
        var books = await _bookRepository.GetBooksByAuthorIdAsync(authorId);
        return books.MapToContract();
    }
    
    public async Task<IEnumerable<BookResponse>> GetBooksByPublisherIdAsync(int authorId)
    {
        var books = await _bookRepository.GetBooksByPublisherIdAsync(authorId);
        return books.MapToContract();
    }

    public async Task<bool> BookExistsAsync(int id)
    {
        return await _bookRepository.BookExistsAsync(id);
    }
}
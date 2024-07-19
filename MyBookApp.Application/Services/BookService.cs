using MyBookApp.Application.Contracts;
using MyBookApp.Application.Interfaces;
using MyBookApp.Application.Mappers;
using MyBookApp.Application.Validators;
using MyBookApp.Core.Exceptions;
using MyBookApp.Core.Models;
using MyBookApp.DataAccess.Interfaces;

namespace MyBookApp.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IPublisherRepository _publisherRepository;
    public BookService(IBookRepository bookRepository,IAuthorRepository authorRepository,IPublisherRepository publisherRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _publisherRepository = publisherRepository;
    }

    public async Task<int> AddBookAsync(BookRequest bookRequest)
    {
        var isAuthorExists = await _authorRepository.AuthorExistsAsync(bookRequest.AuthorId);
        var isPublisherExists = await _publisherRepository.PublisherExistsAsync(bookRequest.PublisherId);
        bookRequest.AddValidation(isAuthorExists,isPublisherExists);
        return await _bookRepository.AddBookAsync(bookRequest.MapToCore());
    }

    public async Task DeleteBookAsync(int id)
    {
        var isBookExists = await BookExistsAsync(id);
        if (!isBookExists)
        {
            throw new BookNotFoundException(id);
        }
        await _bookRepository.DeleteBookAsync(id);
    }

    public async Task<BookResponse> GetBookAsync(int id)
    {
        var isBookExists = await BookExistsAsync(id);
        if (!isBookExists)
        {
            throw new BookNotFoundException(id);
        }
        var book = await _bookRepository.GetBookAsync(id);
        return book.MapToContract();
    }

    public async Task UpdateBookAsync(int id, BookRequest bookRequest)
    {
        var isBookExists = await BookExistsAsync(id);
        var isAuthorExists =  await _authorRepository.AuthorExistsAsync(bookRequest.AuthorId);
        var isPublisherExists = await _publisherRepository.PublisherExistsAsync(bookRequest.PublisherId);
        bookRequest.UpdateValidation(id,isBookExists, isAuthorExists, isPublisherExists);
        await _bookRepository.UpdateBookAsync(id, bookRequest.MapToCore());
    }

    public async Task<IEnumerable<BookResponse>> GetBooksByAuthorIdAsync(int authorId)
    {
        var isAuthorExists = await _authorRepository.AuthorExistsAsync(authorId);
        if (!isAuthorExists)
        {
            throw new AuthorNotFoundException(authorId);
        }
        var books = await _bookRepository.GetBooksByAuthorIdAsync(authorId);
        return books.MapToContract();
    }
    
    public async Task<IEnumerable<BookResponse>> GetBooksByPublisherIdAsync(int publisherId)
    {
        var isPublisherExists = await _publisherRepository.PublisherExistsAsync(publisherId);
        if (!isPublisherExists)
        {
            throw new AuthorNotFoundException(publisherId);
        }
        var books = await _bookRepository.GetBooksByPublisherIdAsync(publisherId);
        return books.MapToContract();
    }

    public async Task<bool> BookExistsAsync(int id)
    {
        return await _bookRepository.BookExistsAsync(id);
    }
}
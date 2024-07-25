using FakeItEasy;
using FluentAssertions;
using MyBookApp.Application.Contracts;
using MyBookApp.Application.Services;
using MyBookApp.Core.Exceptions;
using MyBookApp.Core.Models;
using MyBookApp.DataAccess.Interfaces;

namespace MyBookApp.Tests;

public class BookServiceTests
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IPublisherRepository _publisherRepository;
    private readonly BookService _bookService;

    public BookServiceTests()
    {
        _bookRepository = A.Fake<IBookRepository>();
        _authorRepository = A.Fake<IAuthorRepository>();
        _publisherRepository = A.Fake<IPublisherRepository>();
        _bookService = new BookService(_bookRepository, _authorRepository, _publisherRepository);
    }
    
    [Fact]
    public async Task AddBookAsync_WithValidRequest_ShouldAddBook()
    {
        // Arrange
        var bookRequest = new BookRequest { AuthorId = 1, PublisherId = 1 ,Name = "Book",Description = "Desc"};

        A.CallTo(() => _authorRepository.AuthorExistsAsync(bookRequest.AuthorId)).Returns(true);
        A.CallTo(() => _publisherRepository.PublisherExistsAsync(bookRequest.PublisherId)).Returns(true);
        A.CallTo(() => _bookRepository.AddBookAsync(A<Book>._)).Returns(1);

        // Act
        var result = await _bookService.AddBookAsync(bookRequest);

        // Assert
        result.Should().Be(1);
        A.CallTo(() => _bookRepository.AddBookAsync(A<Book>._)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async Task DeleteBookAsync_WithValidId_ShouldDeleteBook()
    {
        // Arrange
        var bookId = 1;
        A.CallTo(() => _bookRepository.BookExistsAsync(bookId)).Returns(true);

        // Act
        await _bookService.DeleteBookAsync(bookId);

        // Assert
        A.CallTo(() => _bookRepository.DeleteBookAsync(bookId)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async Task DeleteBookAsync_WithInvalidId_ShouldThrowBookNotFoundException()
    {
        // Arrange
        var bookId = 1;
        A.CallTo(() => _bookRepository.BookExistsAsync(bookId)).Returns(false);

        // Act
        Func<Task> act = async () => await _bookService.DeleteBookAsync(bookId);

        // Assert
        await act.Should().ThrowAsync<BookNotFoundException>()
            .WithMessage($"Книга с id {bookId} не найдена.");
    }

    [Fact]
    public async Task GetBookAsync_WithValidId_ShouldReturnBookResponse()
    {
        // Arrange
        var bookId = 1;
        var book = new Book { Id = bookId, Name = "Test Book" };

        A.CallTo(() => _bookRepository.BookExistsAsync(bookId)).Returns(true);
        A.CallTo(() => _bookRepository.GetBookAsync(bookId)).Returns(book);

        // Act
        var result = await _bookService.GetBookAsync(bookId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(bookId);
        A.CallTo(() => _bookRepository.GetBookAsync(bookId)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async Task GetBookAsync_WithInvalidId_ShouldThrowBookNotFoundException()
    {
        // Arrange
        var bookId = 1;
        A.CallTo(() => _bookRepository.BookExistsAsync(bookId)).Returns(false);

        // Act
        Func<Task> act = async () => await _bookService.GetBookAsync(bookId);

        // Assert
        await act.Should().ThrowAsync<BookNotFoundException>()
            .WithMessage($"Книга с id {bookId} не найдена.");
    }

    [Fact]
    public async Task UpdateBookAsync_WithValidRequest_ShouldUpdateBook()
    {
        // Arrange
        var bookId = 1;
        var bookRequest = new BookRequest { AuthorId = 1, PublisherId = 1 };

        A.CallTo(() => _bookRepository.BookExistsAsync(bookId)).Returns(true);
        A.CallTo(() => _authorRepository.AuthorExistsAsync(bookRequest.AuthorId)).Returns(true);
        A.CallTo(() => _publisherRepository.PublisherExistsAsync(bookRequest.PublisherId)).Returns(true);

        // Act
        await _bookService.UpdateBookAsync(bookId, bookRequest);

        // Assert
        A.CallTo(() => _bookRepository.UpdateBookAsync(bookId, A<Book>._)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async Task GetBooksByAuthorIdAsync_WithValidAuthorId_ShouldReturnBooks()
    {
        // Arrange
        var authorId = 1;
        var books = new List<Book> { new Book { Id = 1, AuthorId = authorId, Name = "Book 1" } };

        A.CallTo(() => _authorRepository.AuthorExistsAsync(authorId)).Returns(true);
        A.CallTo(() => _bookRepository.GetBooksByAuthorIdAsync(authorId)).Returns(books);

        // Act
        var result = await _bookService.GetBooksByAuthorIdAsync(authorId);

        // Assert
        result.Should().NotBeNullOrEmpty();
        A.CallTo(() => _bookRepository.GetBooksByAuthorIdAsync(authorId)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async Task GetBooksByAuthorIdAsync_WithInvalidAuthorId_ShouldThrowAuthorNotFoundException()
    {
        // Arrange
        var authorId = 1;
        A.CallTo(() => _authorRepository.AuthorExistsAsync(authorId)).Returns(false);

        // Act
        Func<Task> act = async () => await _bookService.GetBooksByAuthorIdAsync(authorId);

        // Assert
        await act.Should().ThrowAsync<AuthorNotFoundException>()
            .WithMessage($"Автор с id {authorId} не найден.");
    }

    [Fact]
    public async Task GetBooksByPublisherIdAsync_WithValidPublisherId_ShouldReturnBooks()
    {
        // Arrange
        var publisherId = 1;
        var books = new List<Book> { new Book { Id = 1, PublisherId = publisherId, Name = "Book 1" } };

        A.CallTo(() => _publisherRepository.PublisherExistsAsync(publisherId)).Returns(true);
        A.CallTo(() => _bookRepository.GetBooksByPublisherIdAsync(publisherId)).Returns(books);

        // Act
        var result = await _bookService.GetBooksByPublisherIdAsync(publisherId);

        // Assert
        result.Should().NotBeNullOrEmpty();
        A.CallTo(() => _bookRepository.GetBooksByPublisherIdAsync(publisherId)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async Task GetBooksByPublisherIdAsync_WithInvalidPublisherId_ShouldThrowPublisherNotFoundException()
    {
        // Arrange
        var publisherId = 1;
        A.CallTo(() => _publisherRepository.PublisherExistsAsync(publisherId)).Returns(false);

        // Act
        Func<Task> act = async () => await _bookService.GetBooksByPublisherIdAsync(publisherId);

        // Assert
        await act.Should().ThrowAsync<PublisherNotFoundException>()
            .WithMessage($"Издатель с id {publisherId} не найден.");
    }

    [Fact]
    public async Task BookExistsAsync_WithValidId_ShouldReturnTrue()
    {
        // Arrange
        var bookId = 1;
        A.CallTo(() => _bookRepository.BookExistsAsync(bookId)).Returns(true);

        // Act
        var result = await _bookService.BookExistsAsync(bookId);

        // Assert
        result.Should().BeTrue();
        A.CallTo(() => _bookRepository.BookExistsAsync(bookId)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async Task BookExistsAsync_WithInvalidId_ShouldReturnFalse()
    {
        // Arrange
        var bookId = 1;
        A.CallTo(() => _bookRepository.BookExistsAsync(bookId)).Returns(false);

        // Act
        var result = await _bookService.BookExistsAsync(bookId);

        // Assert
        result.Should().BeFalse();
        A.CallTo(() => _bookRepository.BookExistsAsync(bookId)).MustHaveHappenedOnceExactly();
    }
}
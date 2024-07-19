using Microsoft.AspNetCore.Mvc;
using MyBookApp.Application.Contracts;
using MyBookApp.Application.Interfaces;

namespace MyBookApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] BookRequest bookRequest)
    {
        var bookId = await _bookService.AddBookAsync(bookRequest);
        return Ok(bookId);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var bookResponse = await _bookService.GetBookAsync(id);
        return Ok(bookResponse);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> UpdateBookAsync(int id, BookRequest bookRequest)
    {
        await _bookService.UpdateBookAsync(id, bookRequest);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBookAsync(int id)
    {
        await _bookService.DeleteBookAsync(id);
        return Ok();
    }

    [HttpGet("publisher/{publisherId:int}")]
    public async Task<IActionResult> GetBooksByPublisherId(int publisherId)
    {
        var selectedBooks = await _bookService.GetBooksByPublisherIdAsync(publisherId);
        return Ok(selectedBooks);
    }
    
    [HttpGet("author/{authorId:int}")]
    public async Task<IActionResult> GetBooksByAuthorId(int authorId)
    {
        var selectedBooks = await _bookService.GetBooksByAuthorIdAsync(authorId);
        return Ok(selectedBooks);
    }
}
using Microsoft.AspNetCore.Mvc;
using MyBookApp.Application.Contracts;
using MyBookApp.Application.Interfaces;
using MyBookApp.Core.Models;

namespace MyBookApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorSevice;

    public AuthorController(IAuthorService authorService)
    {
        _authorSevice = authorService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthor([FromBody] AuthorRequest authorRequest)
    {
        var authorId = await _authorSevice.AddAuthorAsync(authorRequest);
        return Ok(authorId);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var author = await _authorSevice.GetAuthorAsync(id);
        return Ok(author);
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> UpdateAuthorAsync(int id, AuthorRequest authorRequest)
    {
        await _authorSevice.UpdateAuthorAsync(id, authorRequest);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAuthorAsync(int id)
    {
        await _authorSevice.DeleteAuthorAsync(id);
        return Ok();
    }
}
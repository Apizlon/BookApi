using MyBookApp.Application.Contracts;
using MyBookApp.Application.Interfaces;
using MyBookApp.DataAccess.Interfaces;
using MyBookApp.Application.Mappers;
using MyBookApp.Core.Models;

namespace MyBookApp.Application.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<int> AddAuthorAsync(AuthorRequest authorRequest)
    {
        return await _authorRepository.AddAuthorAsync(authorRequest.MapToCore());
    }

    public async Task DeleteAuthorAsync(int id)
    {
        await _authorRepository.DeleteAuthorAsync(id);
    }

    public async Task<AuthorResponse> GetAuthorAsync(int id)
    {
        var author = await _authorRepository.GetAuthorAsync(id);
        return author.MapToContract();
    }

    public async Task UpdateAuthorAsync(int id, AuthorRequest authorRequest)
    {
        await _authorRepository.UpdateAuthorAsync(id, authorRequest.MapToCore());
    }

    public async Task<bool> AuthorExistsAsync(int id)
    {
        return await _authorRepository.AuthorExistsAsync(id);
    }
}
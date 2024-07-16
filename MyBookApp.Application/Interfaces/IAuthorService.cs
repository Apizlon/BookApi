using MyBookApp.Application.Contracts;
using MyBookApp.Core.Models;

namespace MyBookApp.Application.Interfaces;

public interface IAuthorService
{
    Task<int> AddAuthorAsync(AuthorRequest authorRequest);
    Task DeleteAuthorAsync(int id);
    Task<AuthorResponse> GetAuthorAsync(int id);
    Task UpdateAuthorAsync(int id, AuthorRequest authorRequest);
    Task<bool> AuthorExistsAsync(int id);
}
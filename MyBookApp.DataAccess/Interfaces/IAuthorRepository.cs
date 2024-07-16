using MyBookApp.Core.Models;

namespace MyBookApp.DataAccess.Interfaces;

public interface IAuthorRepository
{
    Task<int> AddAuthorAsync(Author author);
    Task DeleteAuthorAsync(int id);
    Task<Author> GetAuthorAsync(int id);
    Task UpdateAuthorAsync(int id, Author author);
    Task<bool> AuthorExistsAsync(int id);
}
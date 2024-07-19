using MyBookApp.Application.Contracts;
using MyBookApp.Core.Exceptions;


namespace MyBookApp.Application.Validators;

public static class AuthorValidator
{
    public static void AddValidation(this AuthorRequest authorRequest)
    {
        if (string.IsNullOrEmpty(authorRequest.FullName) || authorRequest.FullName.Length > 50)
        {
            throw new ValidationException("Имя должно быть непустым, длиной до 50 символов");
        }

        if (authorRequest.DateOfBirth >= DateTime.Today)
        {
            throw new ValidationException("Дата должна быть ранее сегодняшнего дня");
        }
    }

    public static void UpdateValidation(this AuthorRequest authorRequest, int id, bool isAuthorExists)
    {
        if (!isAuthorExists)
        {
            throw new AuthorNotFoundException(id);
        }

        if (authorRequest.FullName != null)
        {
            if (authorRequest.FullName == "" || authorRequest.FullName.Length > 50)
            {
                throw new ValidationException("Имя должно быть непустым, длиной до 50 символов");
            }
        }
        
        if (authorRequest.DateOfBirth >= DateTime.Today)
        {
            throw new ValidationException("Дата должна быть ранее сегодняшнего дня");
        }
    }
}
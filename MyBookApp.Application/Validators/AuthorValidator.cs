using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;
using MyBookApp.Application.Contracts;
using MyBookApp.Core.Exceptions;
using MyBookApp.Core.Models;

namespace MyBookApp.Application.Validators;

public static class AuthorValidator
{
    private static readonly string DatePattern = 
        @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.([0-9]{4})$";
 
    public static void AddValidation(this AuthorRequest authorRequest)
    {
        if (string.IsNullOrEmpty(authorRequest.FullName) || authorRequest.FullName.Length>50)
        {
            throw new ValidationException("Имя должно быть непустым, длиной до 50 символов");
        }

        if (!new Regex(DatePattern).IsMatch(authorRequest.DateOfBirth))
        {
            throw new ValidationException("Дата должна соответствовать формату dd.mm.yyyy");
        }
    }

    public static void UpdateValidation(this AuthorRequest authorRequest,int id,bool isAuthorExists)
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

        if (authorRequest.DateOfBirth == null)
        {
            if (!new Regex(DatePattern).IsMatch(authorRequest.DateOfBirth))
            {
                throw new ValidationException("Дата должна соответствовать формату dd.mm.yyyy");
            }
        }
    }
}
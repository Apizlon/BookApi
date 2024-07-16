using Microsoft.Extensions.DependencyInjection;
using MyBookApp.DataAccess.Interfaces;
using MyBookApp.DataAccess.Repositories;


namespace MyBookApp.DataAccess.Extensions;

public static class RepositoriesExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IAuthorRepository, AuthorRepository>()
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<IPublisherRepository, PublisherRepository>();
    }
}
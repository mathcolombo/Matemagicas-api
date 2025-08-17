using Matemagicas.Domain.Games.Repositories.Interfaces;
using Matemagicas.Domain.Games.Services;
using Matemagicas.Domain.Games.Services.Interfaces;
using Matemagicas.Domain.Questions.Repositories.Interfaces;
using Matemagicas.Domain.Questions.Services;
using Matemagicas.Domain.Questions.Services.Interfaces;
using Matemagicas.Domain.Users.Repositories.Interfaces;
using Matemagicas.Domain.Users.Services;
using Matemagicas.Domain.Users.Services.Interfaces;
using Matemagicas.Domain.Utils.Repositories.Interfaces;
using Matemagicas.Infrastructure.Games.Repositories;
using Matemagicas.Infrastructure.Questions.Repositories;
using Matemagicas.Infrastructure.Users.Repositories;
using Matemagicas.Infrastructure.Utils.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Matemagicas.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddAbstractions(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(typeof(Repository<>).Assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(Repository<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IGamesService, GamesService>();
        services.AddScoped<IQuestionsService, QuestionsService>();
        services.AddScoped<IUsersService, UsersService>();
        return services;
    }

    public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IGamesRepository, GamesRepository>();
        services.AddScoped<IQuestionsRepository, QuestionsRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        return services;
    }
}
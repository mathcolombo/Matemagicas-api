using Matemagicas.Application.Classes.DataTransfer.Mappings;
using Matemagicas.Application.Classes.Services;
using Matemagicas.Application.Classes.Services.Interfaces;
using Matemagicas.Application.Games.DataTransfer.Mappings;
using Matemagicas.Application.Games.Services;
using Matemagicas.Application.Games.Services.Interfaces;
using Matemagicas.Application.Questions.DataTransfer.Mappings;
using Matemagicas.Application.Questions.Services;
using Matemagicas.Application.Questions.Services.Interfaces;
using Matemagicas.Application.Schools.DataTransfer.Mappings;
using Matemagicas.Application.Schools.Services;
using Matemagicas.Application.Schools.Services.Interfaces;
using Matemagicas.Application.Topics.Services;
using Matemagicas.Application.Topics.Services.Interfaces;
using Matemagicas.Application.Users.DataTransfer.Mappings;
using Matemagicas.Application.Users.Services;
using Matemagicas.Application.Users.Services.Interfaces;
using Matemagicas.Domain.Classes.Repositories.Interfaces;
using Matemagicas.Domain.Classes.Services;
using Matemagicas.Domain.Classes.Services.Interfaces;
using Matemagicas.Domain.Games.Repositories.Interfaces;
using Matemagicas.Domain.Games.Services;
using Matemagicas.Domain.Games.Services.Interfaces;
using Matemagicas.Domain.Questions.Repositories.Interfaces;
using Matemagicas.Domain.Questions.Services;
using Matemagicas.Domain.Questions.Services.Interfaces;
using Matemagicas.Domain.Schools.Repositories.Interfaces;
using Matemagicas.Domain.Schools.Services;
using Matemagicas.Domain.Schools.Services.Interfaces;
using Matemagicas.Domain.Topics.Repositories.Interfaces;
using Matemagicas.Domain.Topics.Services;
using Matemagicas.Domain.Topics.Services.Interfaces;
using Matemagicas.Domain.Users.Repositories.Interfaces;
using Matemagicas.Domain.Users.Services;
using Matemagicas.Domain.Users.Services.Interfaces;
using Matemagicas.Domain.Utils.Repositories.Interfaces;
using Matemagicas.Infrastructure.Classes.Repositories;
using Matemagicas.Infrastructure.Games.Repositories;
using Matemagicas.Infrastructure.Questions.Repositories;
using Matemagicas.Infrastructure.Schools.Repositories;
using Matemagicas.Infrastructure.Topics.Repositories;
using Matemagicas.Infrastructure.Users.Repositories;
using Matemagicas.Infrastructure.Utils.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Matemagicas.Ioc;

public static class DependencyInjection
{
    public static void AddAbstractions(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(typeof(Repository<>).Assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(Repository<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ISchoolsAppService, SchoolsAppService>();
        services.AddScoped<IClassesAppService, ClassesAppService>();
        services.AddScoped<IUsersAppService, UsersAppService>();
        services.AddScoped<IQuestionsAppService, QuestionsAppService>();
        services.AddScoped<IGamesAppService, GamesAppService>();
        services.AddScoped<ITopicsAppService, TopicsAppService>();
    }

    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ISchoolsService, SchoolsService>();
        services.AddScoped<IClassesService, ClassesService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IQuestionsService, QuestionsService>();
        services.AddScoped<IGamesService, GamesService>();
        services.AddScoped<ITopicsService, TopicsService>();
    }

    public static void AddInfrastructureRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISchoolsRepository, SchoolsRepository>();
        services.AddScoped<IClassesRepository, ClassesRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IQuestionsRepository, QuestionsRepository>();
        services.AddScoped<IGamesRepository, GamesRepository>();
        services.AddScoped<ITopicsRepository, TopicsRepository>();
    }
}
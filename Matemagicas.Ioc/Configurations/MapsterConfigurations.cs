using Matemagicas.Application.Classes.DataTransfer.Mappings;
using Matemagicas.Application.Games.DataTransfer.Mappings;
using Matemagicas.Application.Questions.DataTransfer.Mappings;
using Matemagicas.Application.Schools.DataTransfer.Mappings;
using Matemagicas.Application.Topics.DataTransfer.Mappings;
using Matemagicas.Application.Users.DataTransfer.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Matemagicas.Ioc.Configurations;

public static class MapsterConfigurations
{
    public static void AddMappingConfigurations(this IServiceCollection services)
    {
        services.RegisterSchoolMaps();
        services.RegisterClassMaps();
        services.RegisterUserMaps();
        services.RegisterQuestionMaps();
        services.RegisterGameMaps();
        services.RegisterTopicsMaps();
    }
}
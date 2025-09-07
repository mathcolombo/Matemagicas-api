using Mapster;
using Matemagicas.Application.Classes.DataTransfer.Requests;
using Matemagicas.Application.Classes.DataTransfer.Responses;
using Matemagicas.Domain.Classes.Entities;
using Matemagicas.Domain.Classes.Services.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Matemagicas.Application.Classes.DataTransfer.Mappings;

public static class ClassMappingConfigurations
{
    public static void RegisterClassMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<Class, ClassResponse>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id.ToString());

        TypeAdapterConfig<ClassCreateRequest, ClassCreateCommand>
            .NewConfig();
        
        TypeAdapterConfig<ClassUpdateRequest, ClassUpdateCommand>
            .NewConfig();
    }
}
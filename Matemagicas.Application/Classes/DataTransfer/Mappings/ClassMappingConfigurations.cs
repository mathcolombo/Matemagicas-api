using Mapster;
using Matemagicas.Application.Classes.DataTransfer.Requests;
using Matemagicas.Application.Classes.DataTransfer.Responses;
using Matemagicas.Application.Utils.ValueObjects;
using Matemagicas.Domain.Classes.Entities;
using Matemagicas.Domain.Classes.Repositories.Filters;
using Matemagicas.Domain.Classes.Services.Commands;
using Matemagicas.Domain.Utils.Extensions;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;

namespace Matemagicas.Application.Classes.DataTransfer.Mappings;

public static class ClassMappingConfigurations
{
    public static void RegisterClassMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<Class, ClassResponse>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id.ToString())
            .Map(dest => dest.SchoolId, src => src.SchoolId.ToString())
            .Map(dest => dest.ProfessorId, src => src.ProfessorId.ToString())
            .Map(dest => dest.StudentsIds, src => (src.StudentsIds ?? Array.Empty<ObjectId>()).Select(s => s.ToString()));

        TypeAdapterConfig<ClassCreateRequest, ClassCreateCommand>
            .NewConfig()
            .Map(dest => dest.SchoolId, src => ObjectId.Parse(src.SchoolId))
            .Map(dest => dest.ProfessorId, src => ObjectId.Parse(src.ProfessorId))
            .Map(dest => dest.StudentsIds, src => (src.StudentsIds ?? Array.Empty<string>()).Select(ObjectId.Parse));
        
        TypeAdapterConfig<ClassUpdateRequest, ClassUpdateCommand>
            .NewConfig()
            .Map(dest => dest.ProfessorId, src => ObjectId.Parse(src.ProfessorId))
            .Map(dest => dest.StudentsIds, src => (src.StudentsIds ?? Array.Empty<string>()).Select(ObjectId.Parse));
        
        TypeAdapterConfig<ClassPagedRequest, ClassPagedFilter>
            .NewConfig()
            .Map(dest => dest.SchoolId, src => src.SchoolId.ToObjectIdOrNullable())
            .Map(dest => dest.ProfessorId, src => src.ProfessorId.ToObjectIdOrNullable())
            .Map(dest => dest.StudentsIds, src => (src.StudentsIds ?? Array.Empty<string>()).Select(ObjectId.Parse));
        
        TypeAdapterConfig<PagedResult<Class>, PagedResult<ClassResponse>>
            .NewConfig();
    }
}
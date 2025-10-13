using Mapster;
using Matemagicas.Application.Users.DataTransfer.Requests;
using Matemagicas.Application.Users.DataTransfer.Responses;
using Matemagicas.Application.Utils.ValueObjects;
using Matemagicas.Domain.Users.Entities;
using Matemagicas.Domain.Users.Repositories.Filters;
using Matemagicas.Domain.Users.Services.Commands;
using Matemagicas.Domain.Utils.Extensions;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;

namespace Matemagicas.Application.Users.DataTransfer.Mappings;

public static class UserMappingConfigurations
{
    public static void RegisterUserMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<User, UserResponse>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id.ToString())
            .Map(dest => dest.SchoolId, src => src.SchoolId.ToString())
            .Map(dest => dest.Email, src => src.Email.Address)
            .Map(dest => dest.Password, src => src.Password.Hash);

        TypeAdapterConfig<UserCreateRequest, UserCreateCommand>
            .NewConfig()
            .Map(dest => dest.SchoolId, src => ObjectId.Parse(src.SchoolId))
            .Map(dest => dest.ClassId, src => ObjectId.Parse(src.ClassId));

        TypeAdapterConfig<UserLoginRequest, UserLoginCommand>
            .NewConfig();
        
        TypeAdapterConfig<UserUpdateRequest, UserUpdateCommand>
            .NewConfig()
            .Map(dest => dest.SchoolId, src => ObjectId.Parse(src.SchoolId))
            .Map(dest => dest.ClassId, src => ObjectId.Parse(src.ClassId));
        
        TypeAdapterConfig<UserPagedRequest, UserPagedFilter>
            .NewConfig()
            .Map(dest => dest.SchoolId, src => src.SchoolId.ToObjectIdOrNullable())
            .Map(dest => dest.ClassId, src => src.ClassId.ToObjectIdOrNullable());
        
        TypeAdapterConfig<PagedResult<User>, PagedResult<UserResponse>>
            .NewConfig();
    }
}
using Mapster;
using Matemagicas.Application.Users.DataTransfer.Requests;
using Matemagicas.Application.Users.DataTransfer.Responses;
using Matemagicas.Domain.Users.Entities;
using Matemagicas.Domain.Users.Services.Commands;
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
            .Map(dest => dest.SchoolId, src => src.SchoolId.ToString());

        TypeAdapterConfig<UserCreateRequest, UserCreateCommand>
            .NewConfig();

        TypeAdapterConfig<UserLoginRequest, UserLoginCommand>
            .NewConfig();
        
        TypeAdapterConfig<UserUpdateRequest, UserUpdateCommand>
            .NewConfig();
    }
}
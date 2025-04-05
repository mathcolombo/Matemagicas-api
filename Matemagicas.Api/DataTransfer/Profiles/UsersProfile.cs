using AutoMapper;
using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Commands;

namespace Matemagicas.Api.DataTransfer.Profiles;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<User, UserResponse>();

        CreateMap<UserRegisterRequest, UserRegisterCommand>();
        CreateMap<UserLoginRequest, UserLoginCommand>();
        CreateMap<UserUpdateCommand, UserUpdateRequest>();
    }
}
using AutoMapper;
using Matemagicas.Api.Dtos.Responses;
using Matemagicas.Api.Entities;

namespace Matemagicas.Api.Dtos.Profiles;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<User, UserResponse>();
    }
}
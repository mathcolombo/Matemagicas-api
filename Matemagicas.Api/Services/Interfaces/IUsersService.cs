using Matemagicas.Api.Entities;
using Matemagicas.Api.Dtos.Requests;

namespace Matemagicas.Api.Services.Interfaces;

public interface IUsersService
{
    User Register(UserRegisterRequest userRegisterRequest);
    User Login(UserLoginRequest userLoginRequest);
    User GetById(int id);
    User Update(UserUpdateRequest userUpdateRequest);
}
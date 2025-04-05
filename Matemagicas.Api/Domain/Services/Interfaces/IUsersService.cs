using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.Domain.Entities;

namespace Matemagicas.Api.Domain.Services.Interfaces;

public interface IUsersService
{
    User Register(UserRegisterRequest userRegisterRequest);
    User Login(UserLoginRequest userLoginRequest);
    User GetById(int id);
    User Update(int id, UserUpdateRequest userUpdateRequest);
    User Inactivate(int id);
    User Delete(int id);
}
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Commands;

namespace Matemagicas.Api.Domain.Services.Interfaces;

public interface IUsersService
{
    User Register(UserRegisterCommand command);
    User Login(UserLoginCommand command);
    User GetById(int id);
    User Update(int id, UserUpdateCommand command);
    User Inactivate(int id);
    User Delete(int id);
}
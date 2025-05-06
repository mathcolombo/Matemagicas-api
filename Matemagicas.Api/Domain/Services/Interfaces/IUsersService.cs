using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Commands;
using MongoDB.Bson;

namespace Matemagicas.Api.Domain.Services.Interfaces;

public interface IUsersService
{
    User Register(UserRegisterCommand command);
    User Login(UserLoginCommand command);
    User GetById(ObjectId id);
    User Update(ObjectId id, UserUpdateCommand command);
    User Inactivate(ObjectId id);
    User Delete(ObjectId id);
    void UpdatePlayerScore(ObjectId id, decimal score);
}
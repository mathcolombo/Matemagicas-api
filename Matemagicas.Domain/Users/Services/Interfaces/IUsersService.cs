using Matemagicas.Domain.Users.Entities;
using Matemagicas.Domain.Users.Services.Commands;
using MongoDB.Bson;

namespace Matemagicas.Domain.Users.Services.Interfaces;

public interface IUsersService
{
    User Register(UserRegisterCommand command);
    User Login(UserLoginCommand command);
    // IQueryable<User> Get(UserPagedFilter filter);
    User GetById(ObjectId id);
    User Update(ObjectId id, UserUpdateCommand command);
    User Inactivate(ObjectId id);
    User Delete(ObjectId id);
    void UpdatePlayerScore(ObjectId id, decimal score);
}
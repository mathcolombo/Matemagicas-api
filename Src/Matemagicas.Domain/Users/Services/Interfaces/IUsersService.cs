using Matemagicas.Domain.Users.Entities;
using Matemagicas.Domain.Users.Services.Commands;
using MongoDB.Bson;

namespace Matemagicas.Domain.Users.Services.Interfaces;

public interface IUsersService
{
    Task<User> InstantiateAsync(UserCreateCommand command);
    Task<User> LoginAsync(UserLoginCommand command);
    Task<User> ValidateAsync(ObjectId id);
    Task<User> UpdateAsync(ObjectId id, UserUpdateCommand command);
    Task<User> InactivateAsync(ObjectId id);
    Task UpdatePlayerScoreAsync(ObjectId id, decimal score);
}
using Matemagicas.Domain.Users.Entities;
using Matemagicas.Domain.Users.Entities.ValueObjects;
using Matemagicas.Domain.Users.Repositories.Interfaces;
using Matemagicas.Domain.Users.Services.Commands;
using Matemagicas.Domain.Users.Services.Interfaces;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Users.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _repository;

    public UsersService(IUsersRepository usersRepository)
    {
        _repository = usersRepository;
    }
    
    public async Task<User> InstantiateAsync(UserCreateCommand command)
    {
        await ValidateEmailExistsAsync(command.Email);
        
        var email = new Email(command.Email);
        var password = new Password(command.Password);

        return new User(command.Name,
                        email,
                        password,
                        command.Role);
    }

    private async Task ValidateEmailExistsAsync(string email)
    {
        User? user = await _repository.GetByEmailAsync(email);
        
        if (user is not null)
            throw new Exception($"Email {email} já está sendo usado!");
    }

    public async Task<User> LoginAsync(UserLoginCommand command)
    {
        User? user = await _repository.GetByEmailAsync(command.Email);
        
        if(user is null)
            throw new Exception("Login inválido, verifique o email informado!");
        
        if(!user.Password.Hash.Equals(command.Password)) throw new Exception("Senha incorreta!");
        
        return user;
    }
    
    public async Task<User> ValidateAsync(ObjectId id) => 
        await _repository.GetByIdAsync(id) ?? throw new NullReferenceException("Usuário não encontrado!");

    public async Task<User> UpdateAsync(ObjectId id, UserUpdateCommand command)
    {
        User user = await ValidateAsync(id);
        var email = new Email(command.Email);
        var password = new Password(command.Password);
        
        user.SetName(command.Name);
        user.SetEmail(email);
        user.SetPassword(password);
        user.SetRole(command.Role);
        
        return _repository.Update(user);
    }

    public async Task<User> InactivateAsync(ObjectId id)
    {
        User user = await ValidateAsync(id);
        user.SetStatus(StatusEnum.Inactive);
        return _repository.Update(user);
    }

    public async Task UpdatePlayerScoreAsync(ObjectId id, decimal score)
    {
        User user = await ValidateAsync(id);
        user.SetTotalScore(user.TotalScore + score ?? score);
    }
}
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Services.Commands;
using Matemagicas.Api.Domain.Services.Interfaces;
using Matemagicas.Api.Domain.Utils.Entities;
using Matemagicas.Api.Infrastructure.Repositories.Interfaces;
using MongoDB.Bson;

namespace Matemagicas.Api.Domain.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
    
    private User Instantiate(UserRegisterCommand command)
    {
        EmailExists(command.Email);
        
        var email = new Email(command.Email);
        var password = new Password(command.Password);

        return new User(command.Name,
                        command.DateOfBirth,
                        email,
                        password);
    }

    private void EmailExists(string email)
    {
        if (_usersRepository.EmailExists(email)) throw new Exception($"Email {email} já está sendo usado!");
    }
    
    public User Register(UserRegisterCommand command)
    {
        User user = Instantiate(command);
        return _usersRepository.Create(user);
    }

    public User Login(UserLoginCommand command)
    {
        User? user = _usersRepository.Query().FirstOrDefault(u => u.Email.Equals(command.Email));
        
        if(user is null) throw new Exception("Login inválido, verifique o email informado!");
        
        if(!user.Password.Value.Equals(command.Password)) throw new Exception("Senha incorreta!");
        
        return user;
    }

    public User GetById(ObjectId id) => _usersRepository.GetById(id) ?? throw new NullReferenceException("Usuário não encontrado!");

    public User Update(ObjectId id, UserUpdateCommand command)
    {
        User user = GetById(id);
        var email = new Email(command.Email);
        var password = new Password(command.Password);
        
        user.SetName(command.Name);
        user.SetDateOfBirth(command.DateOfBirth);
        user.SetEmail(email);
        user.SetPassword(password);
        
        return _usersRepository.Update(user);
    }

    public User Inactivate(ObjectId id)
    {
        User user = GetById(id);
        user.SetStatus(StatusEnum.Inactive);
        return _usersRepository.Update(user);
    }
    
    public User Delete(ObjectId id)
    {
        User user = GetById(id);
        _usersRepository.Delete(user);
        return user;
    }
}
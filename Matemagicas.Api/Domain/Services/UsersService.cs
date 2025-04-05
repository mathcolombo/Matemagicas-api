using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Services.Commands;
using Matemagicas.Api.Domain.Services.Interfaces;
using Matemagicas.Api.Domain.Utils.Entities;
using Matemagicas.Api.Infrastructure.Repositories.Interfaces;

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
        if (_usersRepository.EmailExists(command.Email)) throw new Exception($"Email {command.Email} já está sendo usado!");
        
        var email = new Email(command.Email);
        var password = new Password(command.Password);

        return new User(command.Name,
                        command.DateOfBirth,
                        email,
                        password);
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

    public User GetById(int id) => _usersRepository.GetById(id) ?? throw new NullReferenceException("Usuário não encontrado!");

    public User Update(int id, UserUpdateCommand command)
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

    public User Inactivate(int id)
    {
        User user = GetById(id);
        user.SetStatus(StatusEnum.Inactive);
        return _usersRepository.Update(user);
    }
    
    public User Delete(int id)
    {
        User user = GetById(id);
        _usersRepository.Delete(user);
        return user;
    }
}
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Services.Commands;
using Matemagicas.Api.Domain.Services.Filters;
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
        ValidateEmailExists(command.Email);
        
        var email = new Email(command.Email);
        var password = new Password(command.Password);

        return new User(command.Name,
                        command.DateOfBirth,
                        email,
                        password);
    }

    private void ValidateEmailExists(string email)
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
        User? user = _usersRepository.Query().FirstOrDefault(u => u.Email.Value.Equals(command.Email));
        
        if(user is null) throw new Exception("Login inválido, verifique o email informado!");
        
        if(!user.Password.Value.Equals(command.Password)) throw new Exception("Senha incorreta!");
        
        return user;
    }
    
    public IQueryable<User> Get(UserPagedFilter filter) => _usersRepository.Get(filter);

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

    public void UpdatePlayerScore(ObjectId id, decimal score)
    {
        User user = GetById(id);
        user.SetTotalScore(user.TotalScore + score ?? score);
    }
}
using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
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
    
    private User Instantiate(UserRegisterRequest request)
    {
        if (_usersRepository.EmailExists(request.Email)) throw new Exception($"Email {request.Email} já está sendo usado!");
        
        var email = new Email(request.Email);
        var password = new Password(request.Password);

        return new User(request.Name,
                        request.DateOfBirth,
                        email,
                        password);
    }
    
    public User Register(UserRegisterRequest request)
    {
        User user = Instantiate(request);
        return _usersRepository.Create(user);
    }

    public User Login(UserLoginRequest request)
    {
        User? user = _usersRepository.Query().FirstOrDefault(u => u.Email.Equals(request.Email));
        
        if(user is null) throw new Exception("Login inválido, verifique o email informado!");
        
        if(!user.Password.Value.Equals(request.Password)) throw new Exception("Senha incorreta!");
        
        return user;
    }

    public User GetById(int id) => _usersRepository.GetById(id) ?? throw new NullReferenceException("Usuário não encontrado!");

    public User Update(int id, UserUpdateRequest request)
    {
        User user = GetById(id);
        var email = new Email(request.Email);
        var password = new Password(request.Password);
        
        user.SetName(request.Name);
        user.SetDateOfBirth(request.DateOfBirth);
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
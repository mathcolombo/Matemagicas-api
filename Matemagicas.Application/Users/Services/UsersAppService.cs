using Mapster;
using Matemagicas.Application.Users.DataTransfer.Requests;
using Matemagicas.Application.Users.DataTransfer.Responses;
using Matemagicas.Application.Users.Services.Interfaces;
using Matemagicas.Application.Utils.Mappings;
using Matemagicas.Application.Utils.ValueObjects;
using Matemagicas.Domain.Users.Repositories.Filters;
using Matemagicas.Domain.Users.Repositories.Interfaces;
using Matemagicas.Domain.Users.Services.Commands;
using Matemagicas.Domain.Users.Services.Interfaces;
using Matemagicas.Domain.Utils.Repositories.Interfaces;
using MongoDB.Bson;

namespace Matemagicas.Application.Users.Services;

public class UsersAppService : IUsersAppService
{
    private readonly IUsersRepository _repository;
    private readonly IUsersService _service;
    private readonly IUnitOfWork _unitOfWork;

    public UsersAppService(IUsersRepository repository,
        IUsersService service,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _service = service;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<UserResponse> CreateAsync(UserCreateRequest request)
    {
        try
        {
            var command = request.Adapt<UserCreateCommand>();
            var user = await _service.InstantiateAsync(command);
            
            await _repository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync();
            
            return user.Adapt<UserResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<UserResponse> LoginAsync(UserLoginRequest request)
    {
        try
        {
            var command = request.Adapt<UserLoginCommand>();
            var user = await _service.LoginAsync(command);
            return user.Adapt<UserResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<PagedResult<UserResponse>> GetAsync(UserPagedRequest request)
    {
        var filter = request.Adapt<UserPagedFilter>();
        var query = _repository.Get(filter);
        
        var pagedUsers = await query.MapToPagedResult(request.PageNumber, request.PageSize);
        return pagedUsers.Adapt<PagedResult<UserResponse>>();
    }

    public async Task<UserResponse> GetByIdAsync(string id)
    {
        var user = await _service.ValidateAsync(ObjectId.Parse(id));
        return user.Adapt<UserResponse>();
    }

    public async Task<UserResponse> UpdateAsync(string id, UserUpdateRequest request)
    {
        try
        {
            var command = request.Adapt<UserUpdateCommand>();
            var user = await _service.UpdateAsync(ObjectId.Parse(id), command);
            
            _repository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            
            return user.Adapt<UserResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<UserResponse> InactivateAsync(string id)
    {
        try
        {
            var user = await _service.InactivateAsync(ObjectId.Parse(id));
            
            _repository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            
            return user.Adapt<UserResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            var user = await _service.ValidateAsync(ObjectId.Parse(id));
            _repository.Delete(user);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
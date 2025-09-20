using Matemagicas.Application.Users.DataTransfer.Requests;
using Matemagicas.Application.Users.DataTransfer.Responses;

namespace Matemagicas.Application.Users.Services.Interfaces;

public interface IUsersAppService
{
    Task<UserResponse> CreateAsync(UserCreateRequest request);
    Task<UserResponse> LoginAsync(UserLoginRequest request);
    Task<UserResponse> GetByIdAsync(string id);
    Task<UserResponse> UpdateAsync(string id, UserUpdateRequest request);
    Task<UserResponse> InactivateAsync(string id);
    Task DeleteAsync(string id);
}
using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Commands;

namespace Matemagicas.Api.Domain.Extensions;

public static class UserExtension
{
    public static UserResponse MapToUserResponse(this User user) =>
        new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            DateOfBirth = user.DateOfBirth,
            Email = user.Email.Value,
            Password = user.Password.Value,
            TotalScore = user.TotalScore,
            Role = (int)user.Role,
            Status = (int)user.Status,
            GameHistory = user.GameHistory
        };

    public static UserRegisterCommand MapToUserRegisterCommand(this UserRegisterRequest request) =>
        new UserRegisterCommand()
        {
            Name = request.Name,
            DateOfBirth = request.DateOfBirth,
            Email = request.Email,
            Password = request.Password,
        };

    public static UserLoginCommand MapToUserLoginCommand(this UserLoginRequest request) =>
        new UserLoginCommand()
        {
            Email = request.Email,
            Password = request.Password
        };
    
    public static UserUpdateCommand MapToUserUpdateCommand(this UserUpdateRequest request) =>
        new UserUpdateCommand()
        {
            Name = request.Name,
            DateOfBirth = request.DateOfBirth,
            Email = request.Email,
            Password = request.Password,
        };
}
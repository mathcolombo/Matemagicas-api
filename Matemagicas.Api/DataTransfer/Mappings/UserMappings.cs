using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Services.Commands;
using Matemagicas.Api.Domain.Services.Filters;

namespace Matemagicas.Api.DataTransfer.Mappings;
public static class UserMappings
{
    public static UserResponse MapToUserResponse(this User user) =>
        new UserResponse
        {
            Id = user.Id.ToString(),
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

    public static UserPagedFilter MapToUserPagedFilter(this UserPagedRequest request) =>
        new UserPagedFilter()
        {
            Name = request.Name,
            DateOfBirth = request.DateOfBirth,
            TotalScore = request.TotalScore,
            Role = request.Role is null ? null : (RoleEnum)request.Role,
            Status = request.Status is null ? null : (StatusEnum)request.Status,
        };
}
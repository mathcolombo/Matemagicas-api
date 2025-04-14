using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;

namespace Matemagicas.Api.Domain.Extensions;

public static class UserExtension
{
    public static UserResponse MapToUserResponse(this User user) => new UserResponse
    {
        Id = user.Id,
        Name = user.Name,
        DateOfBirth = user.DateOfBirth,
        Email = user.Email.Value,
        Password = user.Password.Value,
        TotalScore = user.TotalScore,
        Status = (int)user.Status,
        GameHistory = user.GameHistory
    };
}
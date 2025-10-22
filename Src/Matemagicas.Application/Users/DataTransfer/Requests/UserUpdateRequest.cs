using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Application.Users.DataTransfer.Requests;

public record UserUpdateRequest(
    string Name,
    string Email,
    string Password,
    RoleEnum Role,
    string SchoolId,
    string? ClassId
);
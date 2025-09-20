using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Application.Users.DataTransfer.Requests;

public record UserCreateRequest(
    string Name,
    string Email,
    string Password,
    RoleEnum Role
);
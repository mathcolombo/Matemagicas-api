namespace Matemagicas.Application.Users.DataTransfer.Requests;

public record UserLoginRequest(
    string Email,
    string Password
);
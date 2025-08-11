namespace Matemagicas.Application.Users.DataTransfer.Requests;

public record UserRegisterRequest(string Name,
                                DateOnly DateOfBirth,
                                string Email,
                                string Password);
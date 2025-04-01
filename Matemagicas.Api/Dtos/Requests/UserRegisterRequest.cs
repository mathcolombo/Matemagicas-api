namespace Matemagicas.Api.Dtos.Requests;

public record UserRegisterRequest(string Name,
                                DateOnly DateOfBirth,
                                string Email,
                                string Password);
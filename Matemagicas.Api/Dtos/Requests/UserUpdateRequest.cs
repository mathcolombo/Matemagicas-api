namespace Matemagicas.Api.Dtos.Requests;

public record UserUpdateRequest(string Name,
                                DateOnly DateOfBirth,
                                string Email,
                                string Password);
namespace Matemagicas.Api.DataTransfer.Requests;

public record UserUpdateRequest(string Name,
                                DateOnly DateOfBirth,
                                string Email,
                                string Password);
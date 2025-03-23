namespace Matemagicas.Api.Dtos.Requests;

public class UserRegisterRequest(string Name,
                                DateOnly DateOfBirth,
                                string Email,
                                string Password);
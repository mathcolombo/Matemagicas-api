namespace Matemagicas.Api.Domain.Services.Commands;

public class UserRegisterCommand
{
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
}
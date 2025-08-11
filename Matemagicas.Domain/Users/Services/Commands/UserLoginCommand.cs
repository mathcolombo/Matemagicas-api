namespace Matemagicas.Domain.Users.Services.Commands;

public class UserLoginCommand
{
    public string Email { get; set; }
    public string Password { get; set; }
}
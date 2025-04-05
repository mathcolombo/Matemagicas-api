namespace Matemagicas.Api.Domain.Services.Commands;

public class UserLoginCommand
{
    public string Email { get; set; }
    public string Password { get; set; }
}
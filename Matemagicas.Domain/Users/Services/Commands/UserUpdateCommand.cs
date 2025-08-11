namespace Matemagicas.Domain.Users.Services.Commands;

public class UserUpdateCommand
{
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
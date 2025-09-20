using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Domain.Users.Services.Commands;

public class UserUpdateCommand
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleEnum Role { get; set; }
    
}
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Users.Services.Commands;

public class UserUpdateCommand
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public RoleEnum Role { get; set; }
    public ObjectId SchoolId { get; set; }
    public ObjectId? ClassId { get; set; }
    
}
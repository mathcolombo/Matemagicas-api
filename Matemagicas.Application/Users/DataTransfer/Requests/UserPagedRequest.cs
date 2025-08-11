using Matemagicas.Domain.Users.Entities.ValueObjects;

namespace Matemagicas.Application.Users.DataTransfer.Requests;

public class UserPagedRequest
{
    public string? Name { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public Email? Email { get; set; }
    public Password? Password { get; set; }
    public decimal? TotalScore { get; set; }
    public int? Role { get; set; }
    public int? Status { get; set; }
}
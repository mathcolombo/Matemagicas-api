using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Domain.Users.Repositories.Filters;

public class UserPagedFilter
{
    public string? Name { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public decimal? TotalScore { get; set; }
    public RoleEnum? Role { get; set; }
    public StatusEnum? Status { get; set; }
}
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Utils.Entities;

namespace Matemagicas.Api.Domain.Services.Filters;

public class UserPagedFilter
{
    public string? Name { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public decimal? TotalScore { get; set; }
    public RoleEnum? Role { get; set; }
    public StatusEnum? Status { get; set; }
}
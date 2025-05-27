using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Utils.Entities;

namespace Matemagicas.Api.DataTransfer.Requests;

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
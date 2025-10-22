using Matemagicas.Domain.Users.Entities.ValueObjects;

namespace Matemagicas.Application.Users.DataTransfer.Requests;

public record UserPagedRequest(
    string? Name,
    Email? Email,
    Password? Password,
    decimal? TotalScore,
    int? Role,
    string? SchoolId,
    string? ClassId,
    int? Status,
    int PageNumber,
    int PageSize
);
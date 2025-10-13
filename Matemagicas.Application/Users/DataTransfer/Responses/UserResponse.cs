namespace Matemagicas.Application.Users.DataTransfer.Responses;

public record UserResponse(
    string Id,
    string Name,
    string Email,
    string Password,
    decimal? TotalScore,
    int Role,
    int Status,
    string SchoolId
);
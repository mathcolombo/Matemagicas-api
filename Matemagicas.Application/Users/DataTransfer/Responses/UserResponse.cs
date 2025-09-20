namespace Matemagicas.Application.Users.DataTransfer.Responses;

public record UserResponse
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public decimal? TotalScore { get; init; }
    public int Role { get; init; }
    public int Status { get; init; }
    public string SchoolId { get; init; }
    public IEnumerable<string>? GameHistory { get; init; }
}
namespace Matemagicas.Api.DataTransfer.Responses;

public record UserResponse
{
    public int Id { get; init; }
    public string Name { get; init; }
    public DateOnly DateOfBirth { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public decimal? TotalScore { get; init; }
    public int Status { get; init; }
    public IEnumerable<int>? GameHistory { get; init; }
}
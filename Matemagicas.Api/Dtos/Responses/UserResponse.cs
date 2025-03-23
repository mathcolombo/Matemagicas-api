namespace Matemagicas.Api.Dtos.Responses;

public record UserResponse(int Id,
                        string Name,
                        DateTime DateOfBirth,
                        string Email,
                        string Password,
                        decimal TotalScore,
                        int Status,
                        IEnumerable<GameResponse> GameHistory);
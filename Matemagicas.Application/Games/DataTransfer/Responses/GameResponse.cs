using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Application.Games.DataTransfer.Responses;

public record GameResponse
{
    public string Id { get; init; }
    public string UserId { get; init; }
    public DateTime? Date { get; init; }
    public decimal? Score { get; init; }
    public int? CorrectAnswers { get; init; }
    public int? IncorrectAnswers { get; init; }
    public IEnumerable<string> QuestionsIds { get; init; }
    public IEnumerable<string> TopicsIds { get; init; }
    public DifficultyEnum Difficulty { get; init; }
}

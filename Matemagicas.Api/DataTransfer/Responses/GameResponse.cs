namespace Matemagicas.Api.DataTransfer.Responses;

public record GameResponse
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public DateTime? Date { get; init; }
    public decimal? Score { get; init; }
    public int? CorrectAnswers { get; init; }
    public int? IncorrectAnswers { get; init; }
    public IEnumerable<QuestionResponse> Questions { get; init; }
}

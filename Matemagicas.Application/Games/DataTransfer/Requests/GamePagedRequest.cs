namespace Matemagicas.Application.Games.DataTransfer.Requests;

public class GamePagedRequest
{
    public string? UserId { get; set; }
    public DateTime? Date { get; set; }
    public decimal? Score { get; set; }
    public int? CorrectAnswers { get; set; }
    public int? IncorrectAnswers { get; set; }
    public IEnumerable<string>? QuestionsIds { get; set; }
    public IEnumerable<int>? Topics { get; set; }
}
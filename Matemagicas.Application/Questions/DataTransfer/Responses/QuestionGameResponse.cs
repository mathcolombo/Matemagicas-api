namespace Matemagicas.Application.Questions.DataTransfer.Responses;

public record QuestionGameResponse
{
    public string Id { get; init; }
    public string UserId { get; init; }
    public string QuestionText { get; init; }
    public IEnumerable<string> AnswerOptions { get; init; }
}

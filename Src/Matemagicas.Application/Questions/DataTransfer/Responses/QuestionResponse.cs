namespace Matemagicas.Application.Questions.DataTransfer.Responses;

public record QuestionResponse
{
    public string Id { get; init; }
    public string UserId { get; init; }
    public string QuestionText { get; init; }
    public IEnumerable<string> AnswerOptions { get; init; }
    public int CorrectAnswerIndex { get; init; }
    public int Difficulty { get; init; }
    public string TopicId { get; init; }
}

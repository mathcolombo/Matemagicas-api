using MongoDB.Bson;

namespace Matemagicas.Api.DataTransfer.Responses;

public record QuestionResponse
{
    public ObjectId Id { get; init; }
    public string QuestionText { get; init; }
    public IEnumerable<string> AnswerOptions { get; init; }
    public int CorrectAnswerIndex { get; init; }
    public int Difficulty { get; init; }
    public int Topic { get; init; }
    public int Status { get; init; }
}

using MongoDB.Bson;

namespace Matemagicas.Api.DataTransfer.Responses;

public record GameResponse
{
    public ObjectId Id { get; init; }
    public ObjectId UserId { get; init; }
    public DateTime? Date { get; init; }
    public decimal? Score { get; init; }
    public int? CorrectAnswers { get; init; }
    public int? IncorrectAnswers { get; init; }
    public IEnumerable<ObjectId> QuestionsIds { get; init; }
    public IEnumerable<int> Topics { get; init; }
}

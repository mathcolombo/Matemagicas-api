using Matemagicas.Api.Domain.Enums;
using MongoDB.Bson;

namespace Matemagicas.Api.Domain.Services.Filters;

public class GamePagedFilter
{
    public ObjectId? UserId { get; set; }
    public DateTime? Date { get; set; }
    public decimal? Score { get; set; }
    public int? CorrectAnswers { get; set; }
    public int? IncorrectAnswers { get; set; }
    public IEnumerable<ObjectId>? QuestionsIds { get; set; }
    public IEnumerable<TopicEnum>? Topics { get; set; }
}
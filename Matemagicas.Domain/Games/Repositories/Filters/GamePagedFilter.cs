using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Games.Repositories.Filters;

public class GamePagedFilter
{
    public ObjectId? UserId { get; set; }
    public DateTime? Date { get; set; }
    public decimal? Score { get; set; }
    public int? CorrectAnswers { get; set; }
    public int? IncorrectAnswers { get; set; }
    public IEnumerable<ObjectId>? QuestionsIds { get; set; }
    public IEnumerable<ObjectId>? TopicsIds { get; set; }
}
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Questions.Repositories.Filters;

public class QuestionPagedFilter
{
    public ObjectId? UserId { get; set; }
    public string? QuestionText { get; set; }
    public DifficultyEnum? Difficulty { get; set; }
    public TopicEnum? Topic { get; set; }
}
using Matemagicas.Api.Domain.Enums;
using MongoDB.Bson;

namespace Matemagicas.Api.Domain.Services.Filters;

public class QuestionPagedFilter
{
    public ObjectId? UserId { get; set; }
    public string? QuestionText { get; set; }
    public DifficultyEnum? Difficulty { get; set; }
    public TopicEnum? Topic { get; set; }
    public StatusEnum? Status { get; set; }
}
using Matemagicas.Api.Domain.Enums;
using MongoDB.Bson;

namespace Matemagicas.Api.Domain.Services.Commands;

public class GamePreloadCommand
{
    public ObjectId UserId { get; set; }
    public IEnumerable<TopicEnum> Topics { get; set; }
    public DifficultyEnum Difficulty { get; set; }
}
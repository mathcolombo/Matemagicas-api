using Matemagicas.Api.Domain.Enums;
using MongoDB.Bson;

namespace Matemagicas.Api.Domain.Services.Commands;

public class GamePreloadCommand
{
    public ObjectId UserId { get; protected set; }
    public IEnumerable<TopicEnum> Topics { get; protected set; }
    public DifficultyEnum Difficulty { get; protected set; }
}
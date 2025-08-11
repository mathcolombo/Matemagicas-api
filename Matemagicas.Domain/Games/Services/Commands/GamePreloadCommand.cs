using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Games.Services.Commands;

public class GamePreloadCommand
{
    public ObjectId UserId { get; set; }
    public IEnumerable<TopicEnum> Topics { get; set; }
    public DifficultyEnum Difficulty { get; set; }
}
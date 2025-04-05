using Matemagicas.Api.Enums;

namespace Matemagicas.Api.Services.Commands;

public class GamePreloadCommand
{
    public int UserId { get; protected set; }
    public IEnumerable<TopicEnum> Topics { get; protected set; }
    public DifficultyEnum Difficulty { get; protected set; }
}
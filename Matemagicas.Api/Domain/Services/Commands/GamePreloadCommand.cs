using Matemagicas.Api.Domain.Enums;

namespace Matemagicas.Api.Domain.Services.Commands;

public class GamePreloadCommand
{
    public int UserId { get; protected set; }
    public IEnumerable<TopicEnum> Topics { get; protected set; }
    public DifficultyEnum Difficulty { get; protected set; }
}
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Utils.Entities;
using Matemagicas.Api.Infrastructure.Context;
using Matemagicas.Api.Infrastructure.Repositories.Interfaces;
using Matemagicas.Api.Infrastructure.Utils.Repositories;
using MongoDB.Bson;

namespace Matemagicas.Api.Infrastructure.Repositories;

public class QuestionsRepository : Repository<Question>, IQuestionsRepository
{
    public QuestionsRepository(MatemagicasDbContext context) : base(context)
    {
    }
    
    public IEnumerable<ObjectId> GetByTopicsAndDifficulty(IEnumerable<TopicEnum> topics, DifficultyEnum difficulty, int amount) => Query()
        .Where(q => topics.Contains(q.Topic) && q.Difficulty.Equals(difficulty))
        .Take(amount)
        .Select(q => q.Id);
}
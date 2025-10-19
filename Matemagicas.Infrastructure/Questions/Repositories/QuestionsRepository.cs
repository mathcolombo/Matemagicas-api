using Matemagicas.Domain.Questions.Entities;
using Matemagicas.Domain.Questions.Repositories.Filters;
using Matemagicas.Domain.Questions.Repositories.Interfaces;
using Matemagicas.Domain.Utils.Enums;
using Matemagicas.Infrastructure.Configs.Contexts;
using Matemagicas.Infrastructure.Utils.Repositories;
using MongoDB.Bson;

namespace Matemagicas.Infrastructure.Questions.Repositories;

public class QuestionsRepository : Repository<Question>, IQuestionsRepository
{
    private readonly Random _random = new();
    
    public QuestionsRepository(MatemagicasDbContext context) : base(context)
    {
    }

    public IEnumerable<Question> GetByTopics(IEnumerable<ObjectId> topicsIds, int amount) => Query()
        .Where(q => topicsIds.Contains(q.TopicId))
        .OrderBy(q => _random.Next())
        .Take(amount);

    public IQueryable<Question> Get(QuestionPagedFilter filter)
    {
        var query = Query();
        
        if(filter.UserId.HasValue)
            query = query.Where(q => q.UserId == filter.UserId);
        
        if(!string.IsNullOrWhiteSpace(filter.QuestionText))
            query = query.Where(q => q.QuestionText.Contains(filter.QuestionText));
        
        if(filter.Difficulty.HasValue)
            query = query.Where(q => q.Difficulty == filter.Difficulty);
        
        if(filter.TopicId.HasValue)
            query = query.Where(q => q.TopicId == filter.TopicId);

        return query;
    }
}
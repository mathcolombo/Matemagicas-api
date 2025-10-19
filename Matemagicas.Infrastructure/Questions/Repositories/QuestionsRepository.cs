using Matemagicas.Domain.Questions.Entities;
using Matemagicas.Domain.Questions.Repositories.Filters;
using Matemagicas.Domain.Questions.Repositories.Interfaces;
using Matemagicas.Domain.Utils.Enums;
using Matemagicas.Infrastructure.Configs.Contexts;
using Matemagicas.Infrastructure.Utils.Repositories;

namespace Matemagicas.Infrastructure.Questions.Repositories;

public class QuestionsRepository : Repository<Question>, IQuestionsRepository
{
    private readonly Random _random = new();
    
    public QuestionsRepository(MatemagicasDbContext context) : base(context)
    {
    }

    public IEnumerable<Question> GetByTopics(IEnumerable<TopicEnum> topics, int amount) => Query()
        .Where(q => topics.Contains(q.Topic))
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
        
        if(filter.Topic.HasValue)
            query = query.Where(q => q.Topic == filter.Topic);

        return query;
    }
}
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
    public QuestionsRepository(MatemagicasDbContext context) : base(context)
    {
    }
    
    public IEnumerable<ObjectId> GetByTopicsAndDifficulty(IEnumerable<TopicEnum> topics, DifficultyEnum difficulty, int amount) => Query()
        .Where(q => topics.Contains(q.Topic) && q.Difficulty.Equals(difficulty))
        .Take(amount)
        .Select(q => q.Id);

    public IQueryable<Question> Get(QuestionPagedFilter filter)
    {
        var query = Query();
        
        if(filter.UserId.HasValue)
            query = query.Where(q => q.UserId == filter.UserId);
        
        if(!string.IsNullOrWhiteSpace(filter.QuestionText))
            query = query.Where(q => q.QuestionText.Contains(filter.QuestionText));
        
        if(filter.Difficulty.HasValue)
            query = query.Where(q => q.Difficulty == filter.Difficulty);
        
        if(filter.Difficulty.HasValue)
            query = query.Where(q => q.Difficulty == filter.Difficulty);
        
        if(filter.Difficulty.HasValue)
            query = query.Where(q => q.Difficulty == filter.Difficulty);

        return query;
    }
}
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Services.Filters;
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
        .Where(q => topics.Contains(q.Topic) && q.Difficulty.Equals(difficulty) && q.Status == StatusEnum.Active)
        .Take(amount)
        .Select(q => q.Id);

    public IQueryable<Question> Get(QuestionPagedFilter filter)
    {
        IQueryable<Question> query = Query();
        
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
        
        if(filter.Status.HasValue)
            query = query.Where(q => q.Status == filter.Status);

        return query;
    }
}
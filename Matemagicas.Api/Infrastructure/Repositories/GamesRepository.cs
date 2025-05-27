using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Services.Filters;
using Matemagicas.Api.Infrastructure.Context;
using Matemagicas.Api.Infrastructure.Repositories.Interfaces;
using Matemagicas.Api.Infrastructure.Utils.Repositories;

namespace Matemagicas.Api.Infrastructure.Repositories;

public class GamesRepository : Repository<Game>, IGamesRepository
{
    public GamesRepository(MatemagicasDbContext context) : base(context)
    {
    }

    public IQueryable<Game> Get(GamePagedFilter filter)
    {
        var query = Query();
        
        if(filter.UserId.HasValue)
            query = query.Where(g => g.UserId == filter.UserId);
        
        if(filter.Date.HasValue)
            query = query.Where(g => g.Date == filter.Date);
        
        if(filter.Score.HasValue)
            query = query.Where(g => g.Score == filter.Score);
        
        if(filter.CorrectAnswers.HasValue)
            query = query.Where(g => g.CorrectAnswers == filter.CorrectAnswers);
        
        if(filter.IncorrectAnswers.HasValue)
            query = query.Where(g => g.IncorrectAnswers == filter.IncorrectAnswers);

        if(filter.QuestionsIds != null && filter.QuestionsIds.Any())
            query = query.Where(g => g.QuestionsIds.Any(gameQuestionId => filter.QuestionsIds.Contains(gameQuestionId)));
        
        if(filter.Topics != null && filter.Topics.Any())
            query = query.Where(g => g.Topics.Any(topic => filter.Topics.Contains(topic)));
        
        return query;
    }
}
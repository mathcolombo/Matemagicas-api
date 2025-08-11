using Matemagicas.Domain.Games.Entities;
using Matemagicas.Domain.Games.Repositories.Filters;
using Matemagicas.Domain.Games.Repositories.Interfaces;
using Matemagicas.Infrastructure.Configs.Contexts;
using Matemagicas.Infrastructure.Utils.Repositories;

namespace Matemagicas.Infrastructure.Games.Repositories;

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
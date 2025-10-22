using Matemagicas.Domain.Topics.Entities;
using Matemagicas.Domain.Topics.Repositories.Filters;
using Matemagicas.Domain.Topics.Repositories.Interfaces;
using Matemagicas.Domain.Utils.Enums;
using Matemagicas.Infrastructure.Configs.Contexts;
using Matemagicas.Infrastructure.Utils.Repositories;

namespace Matemagicas.Infrastructure.Topics.Repositories;

public class TopicsRepository : Repository<Topic>, ITopicsRepository
{
    public TopicsRepository(MatemagicasDbContext context) : base(context)
    {
    }

    public IQueryable<Topic> Get(TopicPagedFilter filter)
    {
        IQueryable<Topic> query = Query();
        
        if (filter.Id.HasValue)
            query = query.Where(t => t.Id == filter.Id);
        
        if(!string.IsNullOrWhiteSpace(filter.Title))
            query = query.Where(t => t.Title.Contains(filter.Title));
        
        if(!string.IsNullOrWhiteSpace(filter.Description))
            query = query.Where(t => t.Description.Contains(filter.Description));
        
        if(filter.Series != null && filter.Series.Any())
            query = query.Where(t => (t.Series ?? Array.Empty<SeriesEnum>()).Any(serie => filter.Series.Contains(serie)));
        
        return query;
    }
}
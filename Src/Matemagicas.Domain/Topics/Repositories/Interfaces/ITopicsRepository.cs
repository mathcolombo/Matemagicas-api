using Matemagicas.Domain.Topics.Entities;
using Matemagicas.Domain.Topics.Repositories.Filters;
using Matemagicas.Domain.Utils.Repositories.Interfaces;

namespace Matemagicas.Domain.Topics.Repositories.Interfaces;

public interface ITopicsRepository : IRepository<Topic>
{
    IQueryable<Topic> Get(TopicPagedFilter filter);
}
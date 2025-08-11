using Matemagicas.Domain.Games.Entities;
using Matemagicas.Domain.Games.Repositories.Filters;
using Matemagicas.Infrastructure.Utils.Repositories.Interfaces;

namespace Matemagicas.Domain.Games.Repositories.Interfaces;

public interface IGamesRepository : IRepository<Game>
{
    IQueryable<Game> Get(GamePagedFilter filter);
}
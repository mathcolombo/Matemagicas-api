using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Filters;
using Matemagicas.Api.Infrastructure.Utils.Repositories.Interfaces;

namespace Matemagicas.Api.Infrastructure.Repositories.Interfaces;

public interface IGamesRepository : IRepository<Game>
{
    IQueryable<Game> Get(GamePagedFilter filter);
}
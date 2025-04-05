using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Infrastructure.Context;
using Matemagicas.Api.Infrastructure.Repositories.Interfaces;
using Matemagicas.Api.Infrastructure.Utils.Repositories;

namespace Matemagicas.Api.Infrastructure.Repositories;

public class GamesRepository : Repository<Game>, IGamesRepository
{
    public GamesRepository(MatemagicasDbContext context) : base(context)
    {
    }
}
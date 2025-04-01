using Matemagicas.Api.Context;
using Matemagicas.Api.Entities;
using Matemagicas.Api.Repositories.Interfaces;
using Matemagicas.Api.Utils.Repositories;

namespace Matemagicas.Api.Repositories;

public class GamesRepository : Repository<Game>, IGamesRepository
{
    public GamesRepository(MatemagicasDbContext context) : base(context)
    {
    }
}
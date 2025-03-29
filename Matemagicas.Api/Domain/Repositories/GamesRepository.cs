using Matemagicas.Api.Domain.Context;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Repositories.Interfaces;
using Matemagicas.Api.Utils.Repositories;

namespace Matemagicas.Api.Domain.Repositories;

public class GamesRepository : Repository<Game>, IGamesRepository
{
    public GamesRepository(MatemagicasDbContext context) : base(context)
    {
    }
}
using Matemagicas.Api.Domain.Context;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Repositories.Interfaces;
using Matemagicas.Api.Utils.Repositories;

namespace Matemagicas.Api.Domain.Repositories;

public class UsersRepository : Repository<User>, IUsersRepository
{
    public UsersRepository(MatemagicasDbContext context) : base(context)
    {
    }
}
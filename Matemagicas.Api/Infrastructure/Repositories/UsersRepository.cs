using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Infrastructure.Context;
using Matemagicas.Api.Infrastructure.Repositories.Interfaces;
using Matemagicas.Api.Infrastructure.Utils.Repositories;

namespace Matemagicas.Api.Infrastructure.Repositories;

public class UsersRepository : Repository<User>, IUsersRepository
{
    public UsersRepository(MatemagicasDbContext context) : base(context)
    {
    }
    
    public bool EmailExists(string email) => Query().Any(u => u.Email.Value.Equals(email));
}
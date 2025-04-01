using Matemagicas.Api.Context;
using Matemagicas.Api.Entities;
using Matemagicas.Api.Repositories.Interfaces;
using Matemagicas.Api.Utils.Repositories;

namespace Matemagicas.Api.Repositories;

public class UsersRepository : Repository<User>, IUsersRepository
{
    public UsersRepository(MatemagicasDbContext context) : base(context)
    {
    }
    
    public bool EmailExists(string email) => Query().Any(u => u.Email.Value.Equals(email));
}
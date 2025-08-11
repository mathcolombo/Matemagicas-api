using Matemagicas.Domain.Users.Entities;
using Matemagicas.Domain.Users.Repositories.Filters;
using Matemagicas.Domain.Users.Repositories.Interfaces;
using Matemagicas.Infrastructure.Configs.Contexts;
using Matemagicas.Infrastructure.Utils.Repositories;

namespace Matemagicas.Infrastructure.Users.Repositories;

public class UsersRepository : Repository<User>, IUsersRepository
{
    public UsersRepository(MatemagicasDbContext context) : base(context)
    {
    }
    
    public bool EmailExists(string email) => Query().Any(u => u.Email.Address.Equals(email));
    
    public IQueryable<User> Get(UserPagedFilter filter)
    {
        IQueryable<User> query = Query();

        if(!string.IsNullOrWhiteSpace(filter.Name))
            query = query.Where(u => u.Name.Contains(filter.Name));
        
        if(filter.DateOfBirth.HasValue)
            query = query.Where(u => u.DateOfBirth == filter.DateOfBirth);
        
        if(filter.TotalScore.HasValue)
            query = query.Where(u => u.TotalScore == filter.TotalScore);
        
        if(filter.Role.HasValue)
            query = query.Where(u => u.Role == filter.Role);
        
        if(filter.Status.HasValue)
            query = query.Where(u => u.Status == filter.Status);
        
        return query;
    }
}
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Filters;
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
using Matemagicas.Domain.Users.Entities;
using Matemagicas.Domain.Users.Repositories.Filters;
using Matemagicas.Domain.Users.Repositories.Interfaces;
using Matemagicas.Infrastructure.Configs.Contexts;
using Matemagicas.Infrastructure.Utils.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Matemagicas.Infrastructure.Users.Repositories;

public class UsersRepository : Repository<User>, IUsersRepository
{
    public UsersRepository(MatemagicasDbContext context) : base(context)
    {
    }
    
    public async Task<User?> GetByEmailAsync(string email) => 
        await Query().FirstOrDefaultAsync(u => u.Email.Address.Equals(email));
    
    public IQueryable<User> Get(UserPagedFilter filter)
    {
        IQueryable<User> query = Query();

        if(!string.IsNullOrWhiteSpace(filter.Name))
            query = query.Where(u => u.Name.Contains(filter.Name));
        
        if(filter.TotalScore.HasValue)
            query = query.Where(u => u.TotalScore == filter.TotalScore);
        
        if(filter.Role.HasValue)
            query = query.Where(u => u.Role == filter.Role);
        
        if(filter.SchoolId.HasValue)
            query = query.Where(u => u.SchoolId == filter.SchoolId);
        
        if(filter.ClassId.HasValue)
            query = query.Where(u => u.ClassId == filter.ClassId);
        
        if(filter.Status.HasValue)
            query = query.Where(u => u.Status == filter.Status);
        
        return query;
    }
}
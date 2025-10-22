using Matemagicas.Domain.Schools.Entities;
using Matemagicas.Domain.Schools.Repositories.Filters;
using Matemagicas.Domain.Schools.Repositories.Interfaces;
using Matemagicas.Infrastructure.Configs.Contexts;
using Matemagicas.Infrastructure.Utils.Repositories;

namespace Matemagicas.Infrastructure.Schools.Repositories;

public class SchoolsRepository : Repository<School>, ISchoolsRepository
{
    public SchoolsRepository(MatemagicasDbContext context) : base(context) { }
    
    public IQueryable<School> Get(SchoolPagedFilter filter)
    {
        var query = Query();
        
        if(!string.IsNullOrWhiteSpace(filter.Name))
            query = query.Where(g => g.Name.Contains(filter.Name));

        if(!string.IsNullOrWhiteSpace(filter.Phone))
            query = query.Where(g => g.Phone.Contains(filter.Phone));
        
        return query;
    }
}
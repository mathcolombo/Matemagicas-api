using Matemagicas.Domain.Classes.Entities;
using Matemagicas.Domain.Classes.Repositories.Filters;
using Matemagicas.Domain.Classes.Repositories.Interfaces;
using Matemagicas.Domain.Utils.Enums;
using Matemagicas.Infrastructure.Configs.Contexts;
using Matemagicas.Infrastructure.Utils.Repositories;

namespace Matemagicas.Infrastructure.Classes.Repositories;

public class ClassesRepository : Repository<Class>, IClassesRepository
{
    public ClassesRepository(MatemagicasDbContext context) : base(context) { }
    
    public IQueryable<Class> Get(ClassPagedFilter filter)
    {
        var query = Query().Where(c => c.Status == StatusEnum.Active);
        
        if(!string.IsNullOrWhiteSpace(filter.Name))
            query = query.Where(c => c.Name.Contains(filter.Name));
        
        if(filter.Series.HasValue)
            query = query.Where(c => c.Series == filter.Series);
        
        if(filter.SchoolShift.HasValue)
            query = query.Where(c => c.SchoolShift == filter.SchoolShift);
        
        if(filter.SchoolId.HasValue)
            query = query.Where(c => c.SchoolId == filter.SchoolId);
        
        if(filter.ProfessorId.HasValue)
            query = query.Where(c => c.ProfessorId == filter.ProfessorId);

        if(filter.StudentsIds != null && filter.StudentsIds.Any())
            query = query.Where(c => c.StudentsIds != null && c.StudentsIds.Any(studentId => filter.StudentsIds.Contains(studentId)));
        
        if(filter.AllowedTopics != null && filter.AllowedTopics.Any())
            query = query.Where(c => c.AllowedTopics.Any(allowedTopic => filter.AllowedTopics.Contains(allowedTopic)));
        
        return query;
    }
}
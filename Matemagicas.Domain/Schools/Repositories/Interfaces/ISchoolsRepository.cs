using Matemagicas.Domain.Schools.Entities;
using Matemagicas.Domain.Schools.Repositories.Filters;
using Matemagicas.Domain.Utils.Repositories.Interfaces;

namespace Matemagicas.Domain.Schools.Repositories.Interfaces;

public interface ISchoolsRepository : IRepository<School>
{
    IQueryable<School> Get(SchoolPagedFilter filter);
}
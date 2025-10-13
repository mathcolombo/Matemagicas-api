using Matemagicas.Domain.Classes.Entities;
using Matemagicas.Domain.Classes.Repositories.Filters;
using Matemagicas.Domain.Utils.Repositories.Interfaces;

namespace Matemagicas.Domain.Classes.Repositories.Interfaces;

public interface IClassesRepository : IRepository<Class>
{
    IQueryable<Class> Get(ClassPagedFilter filter);
}
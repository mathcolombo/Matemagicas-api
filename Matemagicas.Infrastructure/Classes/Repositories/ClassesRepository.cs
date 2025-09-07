using Matemagicas.Domain.Classes.Entities;
using Matemagicas.Domain.Classes.Repositories.Interfaces;
using Matemagicas.Infrastructure.Configs.Contexts;
using Matemagicas.Infrastructure.Utils.Repositories;

namespace Matemagicas.Infrastructure.Classes.Repositories;

public class ClassesRepository : Repository<Class>, IClassesRepository
{
    public ClassesRepository(MatemagicasDbContext context) : base(context) { }
}
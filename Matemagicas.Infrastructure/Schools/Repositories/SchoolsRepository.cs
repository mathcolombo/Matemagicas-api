using Matemagicas.Domain.Schools.Entities;
using Matemagicas.Domain.Schools.Repositories.Interfaces;
using Matemagicas.Infrastructure.Configs.Contexts;
using Matemagicas.Infrastructure.Utils.Repositories;

namespace Matemagicas.Infrastructure.Schools.Repositories;

public class SchoolsRepository : Repository<School>, ISchoolsRepository
{
    public SchoolsRepository(MatemagicasDbContext context) : base(context) { }
}
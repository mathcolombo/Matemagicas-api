using Matemagicas.Api.Context;
using Matemagicas.Api.Entities;
using Matemagicas.Api.Repositories.Interfaces;
using Matemagicas.Api.Utils.Repositories;

namespace Matemagicas.Api.Repositories;

public class QuestionsRepository : Repository<Question>, IQuestionsRepository
{
    public QuestionsRepository(MatemagicasDbContext context) : base(context)
    {
    }
}
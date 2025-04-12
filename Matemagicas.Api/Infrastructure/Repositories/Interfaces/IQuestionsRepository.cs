using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Infrastructure.Utils.Repositories.Interfaces;

namespace Matemagicas.Api.Infrastructure.Repositories.Interfaces;

public interface IQuestionsRepository : IRepository<Question>
{
    IEnumerable<int> GetByTopicsAndDifficulty(IEnumerable<TopicEnum> topic, DifficultyEnum difficulty, int amount);
}
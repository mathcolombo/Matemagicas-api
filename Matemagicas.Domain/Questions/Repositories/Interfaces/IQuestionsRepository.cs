using Matemagicas.Domain.Questions.Entities;
using Matemagicas.Domain.Questions.Repositories.Filters;
using Matemagicas.Domain.Utils.Enums;
using Matemagicas.Domain.Utils.Repositories.Interfaces;
using MongoDB.Bson;

namespace Matemagicas.Domain.Questions.Repositories.Interfaces;

public interface IQuestionsRepository : IRepository<Question>
{
    IEnumerable<ObjectId> GetByTopicsAndDifficulty(IEnumerable<TopicEnum> topic, DifficultyEnum difficulty, int amount);
    IQueryable<Question> Get(QuestionPagedFilter filter);
}
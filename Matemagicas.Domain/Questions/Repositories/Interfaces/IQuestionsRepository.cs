using Matemagicas.Domain.Questions.Entities;
using Matemagicas.Domain.Questions.Repositories.Filters;
using Matemagicas.Domain.Utils.Enums;
using Matemagicas.Domain.Utils.Repositories.Interfaces;

namespace Matemagicas.Domain.Questions.Repositories.Interfaces;

public interface IQuestionsRepository : IRepository<Question>
{
    IEnumerable<Question> GetByTopics(IEnumerable<TopicEnum> topics, int amount);
    IQueryable<Question> Get(QuestionPagedFilter filter);
}
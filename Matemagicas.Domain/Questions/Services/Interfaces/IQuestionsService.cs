using Matemagicas.Domain.Questions.Entities;
using Matemagicas.Domain.Questions.Services.Commands;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Questions.Services.Interfaces;

public interface IQuestionsService
{
    Question Create(QuestionCreateCommand command);
    // IQueryable<Question> Get(QuestionPagedFilter filter);
    Question GetById(ObjectId id);
    Question Update(ObjectId id, QuestionUpdateCommand command);
    Question Inactive(ObjectId id);
    IEnumerable<ObjectId> GetByTopicsAndDifficulty(IEnumerable<TopicEnum> topics, DifficultyEnum difficulty, int amount);
}
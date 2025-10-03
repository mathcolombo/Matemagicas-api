using Matemagicas.Domain.Questions.Entities;
using Matemagicas.Domain.Questions.Services.Commands;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Questions.Services.Interfaces;

public interface IQuestionsService
{
    Task<Question> InstantiateAsync(QuestionCreateCommand command);
    Task<Question> CreateAsync(QuestionCreateCommand command);
    Task<Question> ValidateAsync(ObjectId id);
    Task<Question> UpdateAsync(ObjectId id, QuestionUpdateCommand command);
    IEnumerable<Question> GetByTopics(IEnumerable<TopicEnum> topics, int amount);
}
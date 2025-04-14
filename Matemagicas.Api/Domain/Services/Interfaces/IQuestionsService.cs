using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Services.Commands;
using MongoDB.Bson;

namespace Matemagicas.Api.Domain.Services.Interfaces;

public interface IQuestionsService
{
    Question Create(QuestionCreateCommand command);
    Question GetById(ObjectId id);
    Question Update(ObjectId id, QuestionUpdateCommand command);
    Question Inactive(ObjectId id);
    IEnumerable<ObjectId> GetByTopicsAndDifficulty(IEnumerable<TopicEnum> topics, DifficultyEnum difficulty, int amount);
}
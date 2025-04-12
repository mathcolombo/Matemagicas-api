using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Services.Commands;

namespace Matemagicas.Api.Domain.Services.Interfaces;

public interface IQuestionsService
{
    Question Create(QuestionCreateCommand command);
    Question GetById(int id);
    Question Update(int id, QuestionUpdateCommand command);
    Question Inactive(int id);
    IEnumerable<int> GetByTopicsAndDifficulty(IEnumerable<TopicEnum> topics, DifficultyEnum difficulty, int amount);
}
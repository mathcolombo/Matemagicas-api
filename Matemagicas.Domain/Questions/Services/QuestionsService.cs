using Matemagicas.Domain.Questions.Entities;
using Matemagicas.Domain.Questions.Repositories.Interfaces;
using Matemagicas.Domain.Questions.Services.Commands;
using Matemagicas.Domain.Questions.Services.Interfaces;
using Matemagicas.Domain.Topics.Entities;
using Matemagicas.Domain.Topics.Services.Interfaces;
using Matemagicas.Domain.Users.Services.Interfaces;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Questions.Services;

public class QuestionsService(
    IQuestionsRepository questionsRepository,
    IUsersService usersService,
    ITopicsService topicsService
    ) : IQuestionsService
{
    public async Task<Question> InstantiateAsync(QuestionCreateCommand command)
    {
        await usersService.ValidateAsync(command.UserId);
        await topicsService.ValidateAsync(command.TopicId);

        return new Question(command.UserId,
                    command.QuestionText,
                    command.AnswersOptions,
                    command.CorrectAnswerIndex,
                    command.Difficulty,
                    command.TopicId,
                    command.Series);
    }
    
    public async Task<Question> ValidateAsync(ObjectId id) => await questionsRepository.GetByIdAsync(id) ?? throw new NullReferenceException("Questão não encontrada!");

    public async Task<Question> UpdateAsync(ObjectId id, QuestionUpdateCommand command)
    {
        Question question = await ValidateAsync(id);
        await topicsService.ValidateAsync(command.TopicId);
        
        question.SetQuestionText(command.QuestionText);
        question.SetAnswerOptions(command.AnswersOptions);
        question.SetCorrectAnswerIndex(command.CorrectAnswerIndex);
        question.SetDifficulty(command.Difficulty);
        question.SetTopic(command.TopicId);
        
        return questionsRepository.Update(question);
    }

    public IEnumerable<Question> GetByTopics(IEnumerable<ObjectId> topicsIds, int amount) => 
        questionsRepository.GetByTopics(topicsIds, amount);
}
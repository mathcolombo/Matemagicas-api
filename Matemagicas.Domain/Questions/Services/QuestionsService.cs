using Matemagicas.Domain.Questions.Entities;
using Matemagicas.Domain.Questions.Repositories.Interfaces;
using Matemagicas.Domain.Questions.Services.Commands;
using Matemagicas.Domain.Questions.Services.Interfaces;
using Matemagicas.Domain.Users.Entities;
using Matemagicas.Domain.Users.Services.Interfaces;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Questions.Services;

public class QuestionsService : IQuestionsService
{
    private readonly IQuestionsRepository _questionsRepository;
    private readonly IUsersService _usersService;

    public QuestionsService(IQuestionsRepository questionsRepository,
                            IUsersService usersService)
    {
        _questionsRepository = questionsRepository;
        _usersService = usersService;
    }

    public async Task<Question> InstantiateAsync(QuestionCreateCommand command)
    {
        await _usersService.ValidateAsync(command.UserId);

        return new Question(command.UserId,
                    command.QuestionText,
                    command.AnswersOptions,
                    command.CorrectAnswerIndex,
                    command.Difficulty,
                    command.Topic,
                    command.Series);
    }
    
    public async Task<Question> CreateAsync(QuestionCreateCommand command)
    {
        Question question = await InstantiateAsync(command);
        return await _questionsRepository.CreateAsync(question);
    }
    
    public async Task<Question> ValidateAsync(ObjectId id) => await _questionsRepository.GetByIdAsync(id) ?? throw new NullReferenceException("Questão não encontrada!");

    public async Task<Question> UpdateAsync(ObjectId id, QuestionUpdateCommand command)
    {
        Question question = await ValidateAsync(id);
        
        question.SetQuestionText(command.QuestionText);
        question.SetAnswerOptions(command.AnswersOptions);
        question.SetCorrectAnswerIndex(command.CorrectAnswerIndex);
        question.SetDifficulty(command.Difficulty);
        question.SetTopic(command.Topic);
        
        return _questionsRepository.Update(question);
    }

    public IEnumerable<ObjectId> GetByTopicsAndDifficulty(IEnumerable<TopicEnum> topics, DifficultyEnum difficulty, int amount) => _questionsRepository.GetByTopicsAndDifficulty(topics, difficulty, amount);
}
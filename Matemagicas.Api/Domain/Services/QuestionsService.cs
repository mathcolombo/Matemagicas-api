using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Services.Commands;
using Matemagicas.Api.Domain.Services.Filters;
using Matemagicas.Api.Domain.Services.Interfaces;
using Matemagicas.Api.Infrastructure.Repositories.Interfaces;
using MongoDB.Bson;

namespace Matemagicas.Api.Domain.Services;

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

    public Question Instantiate(QuestionCreateCommand command)
    {
        User user = _usersService.GetById(command.UserId);

        return new Question(command.UserId,
                    command.QuestionText,
                    command.AnswersOptions,
                    command.CorrectAnswerIndex,
                    command.Difficulty,
                    command.Topic);
    }
    
    public Question Create(QuestionCreateCommand command)
    {
        Question question = Instantiate(command);
        return _questionsRepository.Create(question);
    }
    
    public IQueryable<Question> Get(QuestionPagedFilter filter) => _questionsRepository.Get(filter);

    public Question GetById(ObjectId id) => _questionsRepository.GetById(id) ?? throw new NullReferenceException("Questão não encontrada!");

    public Question Update(ObjectId id, QuestionUpdateCommand command)
    {
        Question question = GetById(id);
        
        question.SetQuestionText(command.QuestionText);
        question.SetAnswerOptions(command.AnswersOptions);
        question.SetCorrectAnswerIndex(command.CorrectAnswerIndex);
        question.SetDifficulty(command.Difficulty);
        question.SetTopic(command.Topic);
        
        return _questionsRepository.Update(question);
    }

    public Question Inactive(ObjectId id)
    {
        Question question = GetById(id);
        question.SetStatus(StatusEnum.Inactive);
        return _questionsRepository.Update(question);
    }

    public IEnumerable<ObjectId> GetByTopicsAndDifficulty(IEnumerable<TopicEnum> topics, DifficultyEnum difficulty, int amount) => _questionsRepository.GetByTopicsAndDifficulty(topics, difficulty, amount);
}
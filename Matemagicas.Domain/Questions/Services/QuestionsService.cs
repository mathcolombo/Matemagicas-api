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
    
    // public IQueryable<Question> Get(QuestionPagedFilter filter) => _questionsRepository.Get(filter);

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
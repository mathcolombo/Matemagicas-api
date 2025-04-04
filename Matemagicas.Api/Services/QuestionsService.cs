using Matemagicas.Api.Dtos.Requests;
using Matemagicas.Api.Entities;
using Matemagicas.Api.Enums;
using Matemagicas.Api.Repositories.Interfaces;
using Matemagicas.Api.Services.Commands;
using Matemagicas.Api.Services.Interfaces;

namespace Matemagicas.Api.Services;

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

        return new Question(user,
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

    public Question GetById(int id) => _questionsRepository.GetById(id) ?? throw new NullReferenceException("Question not found!");

    public Question Update(int id, QuestionUpdateCommand command)
    {
        Question question = GetById(id);
        
        question.SetQuestionText(command.QuestionText);
        question.SetAnswerOptions(command.AnswersOptions);
        question.SetCorrectAnswerIndex(command.CorrectAnswerIndex);
        question.SetDifficulty(command.Difficulty);
        question.SetTopic(command.Topic);
        
        return _questionsRepository.Update(question);
    }

    public Question Inactive(int id)
    {
        Question question = GetById(id);
        return _questionsRepository.Update(question);
    }
}
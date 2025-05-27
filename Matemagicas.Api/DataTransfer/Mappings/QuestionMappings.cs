using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Domain.Services.Commands;
using Matemagicas.Api.Domain.Services.Filters;
using MongoDB.Bson;

namespace Matemagicas.Api.DataTransfer.Mappings;

public static class QuestionMappings
{
    public static QuestionResponse MapToQuestionResponse(this Question question) =>
        new QuestionResponse
        {
            Id = question.Id.ToString(),
            UserId = question.UserId.ToString(),
            QuestionText = question.QuestionText,
            AnswerOptions = question.AnswerOptions,
            CorrectAnswerIndex = question.CorrectAnswerIndex,
            Difficulty = (int)question.Difficulty,
            Topic = (int)question.Topic,
            Status = (int)question.Status
        };
    
    public static IEnumerable<QuestionResponse> MapToQuestionResponse(this IEnumerable<Question> questions) => 
        questions.Select(question => question.MapToQuestionResponse());

    public static QuestionCreateCommand MapToQuestionCreateCommand(this QuestionCreateRequest request) =>
        new QuestionCreateCommand()
        {
            UserId = ObjectId.Parse(request.UserId),
            QuestionText = request.QuestionText,
            AnswersOptions = request.AnswersOptions,
            CorrectAnswerIndex = request.CorrectAnswerIndex,
            Difficulty = (DifficultyEnum)request.Difficulty,
            Topic = (TopicEnum)request.Topic,
        };
    
    public static QuestionUpdateCommand MapToQuestionUpdateCommand(this QuestionUpdateRequest request) =>
        new QuestionUpdateCommand()
        {
            QuestionText = request.QuestionText,
            AnswersOptions = request.AnswersOptions,
            CorrectAnswerIndex = request.CorrectAnswerIndex,
            Difficulty = (DifficultyEnum)request.Difficulty,
            Topic = (TopicEnum)request.Topic,
        };

    public static QuestionPagedFilter MapToGamePagedFilter(this QuestionsPagedRequest request) =>
        new QuestionPagedFilter()
        {
            UserId = request.UserId is null ? null : ObjectId.Parse(request.UserId),
            QuestionText = request.QuestionText,
            Difficulty = request.Difficulty is null ? null : (DifficultyEnum)request.Difficulty,
            Topic = request.Topic is null ? null : (TopicEnum)request.Topic,
            Status = request.Status is null ? null : (StatusEnum)request.Status
        };
}
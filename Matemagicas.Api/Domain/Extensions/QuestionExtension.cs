using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;

namespace Matemagicas.Api.Domain.Extensions;

public static class QuestionExtension
{
    public static QuestionResponse MapToQuestionResponse(this Question question) => new QuestionResponse
    {
        Id = question.Id,
        QuestionText = question.QuestionText,
        AnswerOptions = question.AnswerOptions,
        CorrectAnswerIndex = question.CorrectAnswerIndex,
        Difficulty = (int)question.Difficulty,
        Topic = (int)question.Topic,
        Status = (int)question.Status
    };
    
    public static IEnumerable<QuestionResponse> MapToQuestionResponse(this IEnumerable<Question> questions) => 
        questions.Select(question => question.MapToQuestionResponse());
}
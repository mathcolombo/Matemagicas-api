using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;

namespace Matemagicas.Api.DataTransfer.Extensions;

public static class QuestionExtension
{
    public static QuestionResponse MapToQuestionResponse(this Question question) => new QuestionResponse
    {
        Id = question.Id,
        QuestionText = question.QuestionText,
        AnswerOptions = question.AnswerOptions,
        CorrectAnswerIndex = question.CorrectAnswerIndex,
        Difficulty = int.Parse(question.Difficulty.ToString()),
        Topic = int.Parse(question.Topic.ToString()),
        Status = int.Parse(question.Status.ToString())
    };
    
    public static IEnumerable<QuestionResponse> MapToQuestionResponse(this IEnumerable<Question> questions) => 
        questions.Select(question => question.MapToQuestionResponse());
}
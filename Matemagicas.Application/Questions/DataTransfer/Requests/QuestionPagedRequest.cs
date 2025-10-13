namespace Matemagicas.Application.Questions.DataTransfer.Requests;

public record QuestionPagedRequest(
    string? UserId,
    string? QuestionText,
    IEnumerable<string>? AnswerOptions,
    int? CorrectAnswerIndex,
    int? Difficulty,
    int? Topic,
    int PageNumber,
    int PageSize
);
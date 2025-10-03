namespace Matemagicas.Application.Questions.DataTransfer.Responses;

public record QuestionGameResponse(
    string Id,
    string UserId,
    string QuestionText,
    IEnumerable<string> AnswerOptions
);

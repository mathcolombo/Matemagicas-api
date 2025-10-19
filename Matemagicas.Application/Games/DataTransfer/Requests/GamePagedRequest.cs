namespace Matemagicas.Application.Games.DataTransfer.Requests;

public record GamePagedRequest(
    string? UserId,
    DateTime? Date,
    decimal? Score,
    int? CorrectAnswers,
    int? IncorrectAnswers,
    IEnumerable<string>? QuestionsIds,
    IEnumerable<string>? TopicsIds,
    int PageNumber,
    int PageSize
);
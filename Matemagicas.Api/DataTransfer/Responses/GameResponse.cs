namespace Matemagicas.Api.DataTransfer.Responses;

public record GameResponse(int Id,
                        int UserId,
                        DateTime Date,
                        decimal Score,
                        int CorrectAnswers,
                        int IncorrectAnswers,
                        IEnumerable<QuestionResponse> Questions);
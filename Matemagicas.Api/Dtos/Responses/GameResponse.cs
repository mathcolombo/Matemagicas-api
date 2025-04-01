using Matemagicas.Api.Entities;

namespace Matemagicas.Api.Dtos.Responses;

public record GameResponse(int Id,
                        int UserId,
                        DateTime Date,
                        decimal Score,
                        int CorrectAnswers,
                        int IncorrectAnswers,
                        IEnumerable<QuestionResponse> Questions);
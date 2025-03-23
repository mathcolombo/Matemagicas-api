namespace Matemagicas.Api.Dtos.Requests;

public record GameSaveRequest(DateTime Date,
                            decimal Score,
                            int CorrectAnswers,
                            int IncorrectAnswers);
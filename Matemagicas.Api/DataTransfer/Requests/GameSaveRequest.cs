namespace Matemagicas.Api.DataTransfer.Requests;

public record GameSaveRequest(DateTime Date,
                            decimal Score,
                            int CorrectAnswers,
                            int IncorrectAnswers);
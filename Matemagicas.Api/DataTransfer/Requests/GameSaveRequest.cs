namespace Matemagicas.Api.DataTransfer.Requests;

public record GameSaveRequest(decimal Score,
                            int CorrectAnswers,
                            int IncorrectAnswers);
namespace Matemagicas.Application.Games.DataTransfer.Requests;

public record GameSaveRequest(decimal Score,
                            int CorrectAnswers,
                            int IncorrectAnswers);
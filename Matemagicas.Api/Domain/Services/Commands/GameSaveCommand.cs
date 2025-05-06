namespace Matemagicas.Api.Domain.Services.Commands;

public class GameSaveCommand
{
    public decimal Score { get; set; }
    public int CorrectAnswers { get; set; }
    public int IncorrectAnswers { get; set; }
}
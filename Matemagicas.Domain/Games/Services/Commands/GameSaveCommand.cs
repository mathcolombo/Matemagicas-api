namespace Matemagicas.Domain.Games.Services.Commands;

public class GameSaveCommand
{
    public decimal Score { get; set; }
    public int CorrectAnswers { get; set; }
    public int IncorrectAnswers { get; set; }
}
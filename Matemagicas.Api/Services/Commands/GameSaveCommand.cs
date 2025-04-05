namespace Matemagicas.Api.Services.Commands;

public class GameSaveCommand
{
    public DateTime Date { get; protected set; }
    public decimal Score { get; protected set; }
    public int CorrectAnswers { get; protected set; }
    public int IncorrectAnswer { get; protected set; }
}
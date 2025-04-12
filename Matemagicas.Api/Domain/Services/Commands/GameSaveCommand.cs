namespace Matemagicas.Api.Domain.Services.Commands;

public class GameSaveCommand
{
    public decimal Score { get; protected set; }
    public int CorrectAnswers { get; protected set; }
    public int IncorrectAnswer { get; protected set; }
}
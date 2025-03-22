using System.Data;

namespace Matemagicas.Api.Models.Entities;

public class Game
{
    public int Id { get; protected set; }
    public int UserId { get; protected set; }
    public DateTime Date { get; protected set; }
    public decimal Score { get; protected set; }
    public int CorrectAnswers { get; protected set; }
    public int IncorrectAnswers { get; protected set; }
    public IEnumerable<int> Questions { get; protected set; }
    
    public Game(int userId,
        DateTime date,
        decimal score,
        int correctAnswers,
        int incorrectAnswers,
        IEnumerable<int> questions)
    {
        SetUserId(userId);
        SetDate(date);
        SetScore(score);
        SetCorrectAnswers(correctAnswers);
        SetIncorrectAnswers(incorrectAnswers);
        SetQuestions(questions);
    }

    public void SetUserId(int userId)
    {
        UserId = userId;
    }

    public void SetDate(DateTime date)
    {
        Date = date;
    }

    public void SetScore(decimal score)
    {
        Score = score;
    }

    public void SetCorrectAnswers(int correctAnswers)
    {
        CorrectAnswers = correctAnswers;
    }

    public void SetIncorrectAnswers(int incorrectAnswers)
    {
        IncorrectAnswers = incorrectAnswers;
    }

    public void SetQuestions(IEnumerable<int> questions)
    {
        Questions = new List<int>(questions);
    }
}
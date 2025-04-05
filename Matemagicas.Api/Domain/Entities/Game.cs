using Matemagicas.Api.Domain.Enums;

namespace Matemagicas.Api.Domain.Entities;

public class Game
{
    public int Id { get; protected set; }
    public int UserId { get; protected set; }
    public DateTime? Date { get; protected set; }
    public decimal? Score { get; protected set; }
    public int? CorrectAnswers { get; protected set; }
    public int? IncorrectAnswers { get; protected set; }
    public IEnumerable<int> QuestionsIds { get; protected set; }
    public IEnumerable<TopicEnum> Topics { get; protected set; }

    #region Navigations

    public User User { get; protected set; }
    public IEnumerable<Question> Questions { get; protected set; }

    #endregion

    public Game()
    {
    }
    
    public Game(int userId,
                IEnumerable<int> questionsIds)
    {
        SetUser(userId);
        SetQuestions(questionsIds);
    }

    public void SetUser(int userId)
    {
        UserId = userId;
    }

    public void SetDate(DateTime? date)
    {
        if(date == DateTime.MinValue)
            throw new FormatException("Date invalid");
        
        Date = date;
    }

    public void SetScore(decimal? score)
    {
        if(score < 0)
            throw new FormatException("Score invalid");
        
        Score = score;
    }

    public void SetCorrectAnswers(int? correctAnswers)
    {
        if(correctAnswers < 0)
            throw new FormatException("CorrectAnswers invalid");
        
        CorrectAnswers = correctAnswers;
    }

    public void SetIncorrectAnswers(int? incorrectAnswers)
    {
        if(incorrectAnswers < 0)
            throw new FormatException("IncorrectAnswers invalid");
        
        IncorrectAnswers = incorrectAnswers;
    }

    public void SetQuestions(IEnumerable<int> questionsIds)
    {
        QuestionsIds = new List<int>(questionsIds);
    }
}
using Matemagicas.Api.Utils.Entities;

namespace Matemagicas.Api.Models.Entities;

public class User
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public int Age { get; protected set; }
    public Email Email { get; protected set; }
    public Password Password { get; protected set; }
    public decimal TotalScore { get; protected set; }
    public IEnumerable<int> GameHistory { get; protected set; }
    
    public User(string name,
        int age,
        Email email,
        Password password,
        int totalScore,
        IEnumerable<int> gameHistory)
    {
        SetName(name);
        SetAge(age);
        SetEmail(email);
        SetPassword(password);
        SetTotalScore(totalScore);
        SetGameHistory(gameHistory);
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetAge(int age)
    {
        Age = age;
    }

    public void SetEmail(Email email)
    {
        Email = email;
    }

    public void SetPassword(Password password)
    {
        Password = password;
    }

    public void SetTotalScore(int totalScore)
    {
        TotalScore = totalScore;
    }

    public void SetGameHistory(IEnumerable<int> gameHistory)
    {
        GameHistory = new List<int>(gameHistory);
    }
}
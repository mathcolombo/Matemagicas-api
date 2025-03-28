using Matemagicas.Api.Domain.Enums;
using Matemagicas.Api.Utils.Entities;

namespace Matemagicas.Api.Domain.Entities;

public class User
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public DateOnly DateOfBirth { get; protected set; }
    public Email Email { get; protected set; }
    public Password Password { get; protected set; }
    public decimal? TotalScore { get; protected set; }
    public StatusEnum Status { get; protected set; }
    public IEnumerable<int>? GameHistory { get; protected set; }
    
    public User(string name,
                DateOnly dateOfBirth,
                Email email,
                Password password,
                decimal? totalScore,
                StatusEnum status,
                IEnumerable<int>? gameHistory)
    {
        SetName(name);
        SetDateOfBirth(dateOfBirth);
        SetEmail(email);
        SetPassword(password);
        SetTotalScore(totalScore);
        SetStatus(status);
        SetGameHistory(gameHistory);
    }

    public void SetName(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new FormatException("Name invalid");
        
        Name = name;
    }

    public void SetDateOfBirth(DateOnly dateOfBirth)
    {
        int age = DateTime.Today.Year - dateOfBirth.Year;
        
        if(age < 6)
            throw new FormatException("Date of birth invalid");
        
        DateOfBirth = dateOfBirth;
    }

    public void SetEmail(Email email)
    {
        Email = email;
    }

    public void SetPassword(Password password)
    {
        Password = password;
    }

    public void SetTotalScore(decimal? totalScore)
    {
        if(totalScore < 0)
            throw new FormatException("Total score invalid");
        
        TotalScore = totalScore;
    }

    public void SetStatus(StatusEnum status)
    {
        Status = status;
    }

    public void SetGameHistory(IEnumerable<int>? gameHistory)
    {
        GameHistory = new List<int>(gameHistory ?? Array.Empty<int>());
    }
}
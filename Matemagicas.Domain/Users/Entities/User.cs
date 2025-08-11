using Matemagicas.Domain.Users.Entities.ValueObjects;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Matemagicas.Domain.Users.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; protected set; }
    public string Name { get; protected set; }
    public DateOnly DateOfBirth { get; protected set; }
    public Email Email { get; protected set; }
    public Password Password { get; protected set; }
    public decimal? TotalScore { get; protected set; }
    public RoleEnum Role { get; protected set; }
    public StatusEnum Status { get; protected set; }
    public IEnumerable<int>? GameHistory { get; protected set; }
    
    public User()
    {
    }
    
    public User(string name,
                DateOnly dateOfBirth,
                Email email,
                Password password)
    {
        SetName(name);
        SetDateOfBirth(dateOfBirth);
        SetEmail(email);
        SetPassword(password);
        SetRole(RoleEnum.Player);
        SetStatus(StatusEnum.Active);
    }

    public void SetName(string name)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new FormatException("Name invalid");
        
        if(name.Length > 100)
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

    public void SetTotalScore(decimal totalScore)
    {
        if(totalScore < 0)
            throw new FormatException("Total score invalid");
        
        TotalScore = totalScore;
    }

    public void SetRole(RoleEnum role)
    {
        Role = role;
    }

    public void SetStatus(StatusEnum status)
    {
        Status = status;
    }

    public void SetGameHistory(IEnumerable<int> gameHistory)
    {
        GameHistory = new List<int>(gameHistory);
    }
}
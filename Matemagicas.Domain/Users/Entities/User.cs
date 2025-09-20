using System.ComponentModel.DataAnnotations.Schema;
using Matemagicas.Domain.Classes.Entities;
using Matemagicas.Domain.Games.Entities;
using Matemagicas.Domain.Schools.Entities;
using Matemagicas.Domain.Users.Entities.ValueObjects;
using Matemagicas.Domain.Utils.Enums;
using Matemagicas.Domain.Utils.Extensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Matemagicas.Domain.Users.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; protected set; }
    public string Name { get; protected set; }
    public Email Email { get; protected set; }
    public Password Password { get; protected set; }
    public decimal? TotalScore { get; protected set; }
    public RoleEnum Role { get; protected set; }
    public StatusEnum Status { get; protected set; }
    public ObjectId SchoolId { get; protected set; }
    public ObjectId? ClassId { get; protected set; }

    #region Navigations
    
    [NotMapped]
    public School School { get; set; }
    [NotMapped]
    public Class? Class { get; set; }

    #endregion
    
    protected User()
    {
    }
    
    public User(string name,
                Email email,
                Password password,
                RoleEnum role)
    {
        SetName(name);
        SetEmail(email);
        SetPassword(password);
        SetRole(role);
        SetStatus(StatusEnum.Active);
    }

    public void SetName(string name)
    {
        name.ValidateProperty(2, 100);
        Name = name;
    }

    public void SetEmail(Email email) => Email = email;
    public void SetPassword(Password password) => Password = password;

    public void SetTotalScore(decimal totalScore)
    {
        totalScore.ValidateProperty(0);
        TotalScore = totalScore;
    }

    public void SetRole(RoleEnum role) => Role = role;
    public void SetStatus(StatusEnum status) => Status = status;
}
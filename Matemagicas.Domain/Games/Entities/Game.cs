using System.ComponentModel.DataAnnotations.Schema;
using Matemagicas.Domain.Questions.Entities;
using Matemagicas.Domain.Users.Entities;
using Matemagicas.Domain.Utils.Enums;
using Matemagicas.Domain.Utils.Extensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Matemagicas.Domain.Games.Entities;

public class Game
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; protected set; }
    public ObjectId UserId { get; protected set; }
    public DateTime? Date { get; protected set; }
    public decimal? Score { get; protected set; }
    public int? CorrectAnswers { get; protected set; }
    public int? IncorrectAnswers { get; protected set; }
    public IList<ObjectId> QuestionsIds { get; protected set; }
    public IList<TopicEnum> Topics { get; protected set; }
    public DifficultyEnum Difficulty { get; protected set; }

    #region Navigations
    
    [NotMapped]
    public User User { get; protected set; }
    [NotMapped]
    public IEnumerable<Question> Questions { get; protected set; }

    #endregion

    protected Game()
    {
    }
    
    public Game(ObjectId userId,
                IEnumerable<ObjectId> questionsIds,
                IEnumerable<TopicEnum> topics,
                DifficultyEnum difficulty)
    {
        SetUser(userId);
        SetQuestions(questionsIds);
        SetTopics(topics);
        SetDifficulty(difficulty);
    }

    public void SetUser(ObjectId userId) => UserId = userId;

    public void SetDate(DateTime date)
    {
        date.ValidateProperty(DateTime.MinValue);
        Date = date;
    }

    public void SetScore(decimal score)
    {
        score.ValidateProperty(0);
        Score = score;
    }

    public void SetCorrectAnswers(int correctAnswers)
    {
        correctAnswers.ValidateProperty(0);
        CorrectAnswers = correctAnswers;
    }

    public void SetIncorrectAnswers(int incorrectAnswers)
    {
        incorrectAnswers.ValidateProperty(0);
        IncorrectAnswers = incorrectAnswers;
    }

    public void SetQuestions(IEnumerable<ObjectId> questionsIds) => QuestionsIds = questionsIds.ToList();
    
    public void SetTopics(IEnumerable<TopicEnum> topics) => Topics = topics.ToList();
    
    public void SetDifficulty(DifficultyEnum difficulty) => Difficulty = difficulty;
}
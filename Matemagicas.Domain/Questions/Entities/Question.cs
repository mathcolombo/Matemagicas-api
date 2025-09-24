using System.ComponentModel.DataAnnotations.Schema;
using Matemagicas.Domain.Users.Entities;
using Matemagicas.Domain.Utils.Enums;
using Matemagicas.Domain.Utils.Extensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Matemagicas.Domain.Questions.Entities;

public class Question
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; protected set; }
    public ObjectId UserId { get; protected set; }
    public string QuestionText { get; protected set; }
    public IEnumerable<string> AnswerOptions { get; protected set; }
    public int CorrectAnswerIndex { get; protected set; }
    public DifficultyEnum Difficulty { get; protected set; }
    public TopicEnum Topic { get; protected set; }
    public SeriesEnum Series { get; protected set; }

    #region Navigations

    [NotMapped]
    public User User { get; protected set; }

    #endregion
    
    protected Question()
    {
    }
    
    public Question(ObjectId userId,
                    string questionText,
                    IEnumerable<string> answerOptions,
                    int correctAnswerIndex,
                    DifficultyEnum difficulty,
                    TopicEnum topic,
                    SeriesEnum series)
    {
        UserId = userId;
        SetQuestionText(questionText);
        SetAnswerOptions(answerOptions);
        SetCorrectAnswerIndex(correctAnswerIndex);
        SetDifficulty(difficulty);
        SetTopic(topic);
        SetSeries(series);
    }
    
    public void SetQuestionText(string questionText)
    {
        questionText.ValidateProperty(5, 500);
        QuestionText = questionText;
    }

    public void SetAnswerOptions(IEnumerable<string> answerOptions) => AnswerOptions = new List<string>(answerOptions);

    public void SetCorrectAnswerIndex(int correctAnswerIndex)
    {
        correctAnswerIndex.ValidateProperty(0, 3);
        CorrectAnswerIndex = correctAnswerIndex;
    }

    public void SetDifficulty(DifficultyEnum difficulty) => Difficulty = difficulty;

    public void SetTopic(TopicEnum topic) => Topic = topic;
    
    public void SetSeries(SeriesEnum series) => Series = series;
}
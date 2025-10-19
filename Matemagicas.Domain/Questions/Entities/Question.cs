using System.ComponentModel.DataAnnotations.Schema;
using Matemagicas.Domain.Topics.Entities;
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
    public ObjectId TopicId { get; protected set; }
    public SeriesEnum Series { get; protected set; }

    #region Navigations

    [NotMapped]
    public User User { get; protected set; }
    [NotMapped]
    public Topic Topic { get; protected set; }

    #endregion
    
    protected Question()
    {
    }
    
    public Question(ObjectId userId,
                    string questionText,
                    IEnumerable<string> answerOptions,
                    int correctAnswerIndex,
                    DifficultyEnum difficulty,
                    ObjectId topicId,
                    SeriesEnum series)
    {
        UserId = userId;
        SetQuestionText(questionText);
        SetAnswerOptions(answerOptions);
        SetCorrectAnswerIndex(correctAnswerIndex);
        SetDifficulty(difficulty);
        SetTopic(topicId);
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

    public void SetTopic(ObjectId topicId) => TopicId = topicId;
    
    public void SetSeries(SeriesEnum series) => Series = series;
}
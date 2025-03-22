using Matemagicas.Api.Models.Enums;

namespace Matemagicas.Api.Models.Entities;

public class Question
{
    public int Id { get; protected set; }
    public string QuestionText { get; protected set; }
    public IEnumerable<string> AnswerOptions { get; protected set; }
    public int CorrectAnswerIndex { get; protected set; }
    public DifficultyEnum Difficulty { get; protected set; }
    public string Topic { get; protected set; }
    
    public Question(string questionText,
        IEnumerable<string> answerOptions,
        int correctAnswerIndex,
        DifficultyEnum difficulty,
        string topic)
    {
        SetQuestionText(questionText);
        SetAnswerOptions(answerOptions);
        SetCorrectAnswerIndex(correctAnswerIndex);
        SetDifficulty(difficulty);
        SetTopic(topic);
    }

    public void SetQuestionText(string questionText)
    {
        QuestionText = questionText;
    }

    public void SetAnswerOptions(IEnumerable<string> answerOptions)
    {
        AnswerOptions = new List<string>(answerOptions);
    }

    public void SetCorrectAnswerIndex(int correctAnswerIndex)
    {
        CorrectAnswerIndex = correctAnswerIndex;
    }

    public void SetDifficulty(DifficultyEnum difficulty)
    {
        Difficulty = difficulty;
    }

    public void SetTopic(string topic)
    {
        Topic = topic;
    }
}
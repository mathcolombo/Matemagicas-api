using Matemagicas.Api.Domain.Enums;

namespace Matemagicas.Api.Domain.Entities;

public class Question
{
    public int Id { get; protected set; }
    public string QuestionText { get; protected set; }
    public IEnumerable<string> AnswerOptions { get; protected set; }
    public int CorrectAnswerIndex { get; protected set; }
    public DifficultyEnum Difficulty { get; protected set; }
    public TopicEnum Topic { get; protected set; }
    public StatusEnum Status { get; protected set; }

    public Question()
    {
    }
    
    public Question(string questionText,
                    IEnumerable<string> answerOptions,
                    int correctAnswerIndex,
                    DifficultyEnum difficulty,
                    TopicEnum topic,
                    StatusEnum status)
    {
        SetQuestionText(questionText);
        SetAnswerOptions(answerOptions);
        SetCorrectAnswerIndex(correctAnswerIndex);
        SetDifficulty(difficulty);
        SetTopic(topic);
        SetStatus(status);
    }

    public void SetQuestionText(string questionText)
    {
        if(string.IsNullOrWhiteSpace(questionText))
            throw new FormatException("Question text invalid");
            
        QuestionText = questionText;
    }

    public void SetAnswerOptions(IEnumerable<string> answerOptions)
    {
        AnswerOptions = new List<string>(answerOptions);
    }

    public void SetCorrectAnswerIndex(int correctAnswerIndex)
    {
        if(correctAnswerIndex is < 0 or > 3)
            throw new FormatException("CorrectAnswerIndex invalid");
        
        CorrectAnswerIndex = correctAnswerIndex;
    }

    public void SetDifficulty(DifficultyEnum difficulty)
    {
        Difficulty = difficulty;
    }

    public void SetTopic(TopicEnum topic)
    {
        Topic = topic;
    }
    
    public void SetStatus(StatusEnum status)
    {
        Status = status;
    }
}
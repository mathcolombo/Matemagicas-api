using Matemagicas.Api.Enums;

namespace Matemagicas.Api.Services.Commands;

public class QuestionCreateCommand
{
    public int UserId { get; set; }
    public string QuestionText { get; set; }
    public IEnumerable<string> AnswersOptions { get; set; }
    public int CorrectAnswerIndex { get; set; }
    public DifficultyEnum Difficulty { get; set; }
    public TopicEnum Topic { get; set; }
}
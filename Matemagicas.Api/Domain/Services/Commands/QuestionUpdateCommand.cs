using Matemagicas.Api.Domain.Enums;

namespace Matemagicas.Api.Domain.Services.Commands;

public class QuestionUpdateCommand
{
    public string QuestionText { get; set; }
    public IEnumerable<string> AnswersOptions { get; set; }
    public int CorrectAnswerIndex { get; set; }
    public DifficultyEnum Difficulty { get; set; }
    public TopicEnum Topic { get; set; }
}
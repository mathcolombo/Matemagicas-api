using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Questions.Services.Commands;

public class QuestionCreateCommand
{
    public ObjectId UserId { get; set; }
    public string QuestionText { get; set; }
    public IEnumerable<string> AnswersOptions { get; set; }
    public int CorrectAnswerIndex { get; set; }
    public DifficultyEnum Difficulty { get; set; }
    public TopicEnum Topic { get; set; }
}
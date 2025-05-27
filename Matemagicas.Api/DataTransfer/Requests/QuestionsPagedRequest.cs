using Matemagicas.Api.Domain.Enums;
using MongoDB.Bson;

namespace Matemagicas.Api.DataTransfer.Requests;

public class QuestionsPagedRequest
{
    public string? UserId { get; set; }
    public string? QuestionText { get; set; }
    public IEnumerable<string>? AnswerOptions { get; set; }
    public int? CorrectAnswerIndex { get; set; }
    public int? Difficulty { get; set; }
    public int? Topic { get; set; }
    public int? Status { get; set; }
}
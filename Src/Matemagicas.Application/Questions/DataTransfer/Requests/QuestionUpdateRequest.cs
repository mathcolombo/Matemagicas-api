using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Application.Questions.DataTransfer.Requests;

public record QuestionUpdateRequest(
    string QuestionText,
    IEnumerable<string> AnswersOptions,
    int CorrectAnswerIndex,
    DifficultyEnum Difficulty,
    string TopicId,
    SeriesEnum Series
);
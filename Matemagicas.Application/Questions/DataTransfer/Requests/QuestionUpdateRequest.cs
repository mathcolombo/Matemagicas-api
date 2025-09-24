using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Application.Questions.DataTransfer.Requests;

public record QuestionUpdateRequest(
    string QuestionText,
    IEnumerable<string> AnswersOptions,
    int CorrectAnswerIndex,
    DifficultyEnum Difficulty,
    TopicEnum Topic,
    SeriesEnum Series
);
namespace Matemagicas.Api.Dtos.Requests;

public record QuestionUpdateRequest(string QuestionText,
                                    IEnumerable<string> AnswersOptions,
                                    int CorrectAnswerIndex,
                                    int Difficulty,
                                    int Topic);
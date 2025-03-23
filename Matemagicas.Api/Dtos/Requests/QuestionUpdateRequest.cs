namespace Matemagicas.Api.Dtos.Requests;

public record QuestionUpdateRequest(string QuestionText,
                                    IEnumerable<int> AnswersOptions,
                                    int CorrectAnswerIndex,
                                    int Difficulty,
                                    int Topic);
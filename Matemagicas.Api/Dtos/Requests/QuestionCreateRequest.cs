namespace Matemagicas.Api.Dtos.Requests;

public record QuestionCreateRequest(string QuestionText,
                                    IEnumerable<int> AnswersOptions,
                                    int CorrectAnswerIndex,
                                    int Difficulty,
                                    int Topic);
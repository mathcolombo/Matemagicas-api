namespace Matemagicas.Api.Dtos.Requests;

public record QuestionInsertRequest(string QuestionText,
                                    IEnumerable<int> AnswersOptions,
                                    int CorrectAnswerIndex,
                                    int Difficulty,
                                    int Topic);
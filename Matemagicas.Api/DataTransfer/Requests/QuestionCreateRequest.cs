namespace Matemagicas.Api.DataTransfer.Requests;

public record QuestionCreateRequest(int UserId,
                                    string QuestionText,
                                    IEnumerable<string> AnswersOptions,
                                    int CorrectAnswerIndex,
                                    int Difficulty,
                                    int Topic);
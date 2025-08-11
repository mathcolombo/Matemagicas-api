namespace Matemagicas.Application.Questions.DataTransfer.Requests;

public record QuestionCreateRequest(string UserId,
                                    string QuestionText,
                                    IEnumerable<string> AnswersOptions,
                                    int CorrectAnswerIndex,
                                    int Difficulty,
                                    int Topic);
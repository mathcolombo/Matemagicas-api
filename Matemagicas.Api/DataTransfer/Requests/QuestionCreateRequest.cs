using MongoDB.Bson;

namespace Matemagicas.Api.DataTransfer.Requests;

public record QuestionCreateRequest(string UserId,
                                    string QuestionText,
                                    IEnumerable<string> AnswersOptions,
                                    int CorrectAnswerIndex,
                                    int Difficulty,
                                    int Topic);
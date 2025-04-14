using MongoDB.Bson;

namespace Matemagicas.Api.DataTransfer.Requests;

public record QuestionCreateRequest(ObjectId UserId,
                                    string QuestionText,
                                    IEnumerable<string> AnswersOptions,
                                    int CorrectAnswerIndex,
                                    int Difficulty,
                                    int Topic);
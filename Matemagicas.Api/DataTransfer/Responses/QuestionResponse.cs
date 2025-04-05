namespace Matemagicas.Api.DataTransfer.Responses;

public record QuestionResponse(int Id,
                            string QuestionText,
                            IEnumerable<string> AnswerOptions,
                            int CorrectAnswerIndex,
                            int Difficulty,
                            int Topic,
                            int Status);
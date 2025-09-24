using Matemagicas.Application.Questions.DataTransfer.Requests;
using Matemagicas.Application.Questions.DataTransfer.Responses;

namespace Matemagicas.Application.Questions.Services.Interfaces;

public interface IQuestionsAppService
{
    Task<QuestionResponse> CreateAsync(QuestionCreateRequest request);
    Task<QuestionResponse> GetByIdAsync(string id);
    Task<QuestionResponse> UpdateAsync(string id, QuestionUpdateRequest request);
}
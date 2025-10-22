using Matemagicas.Application.Questions.DataTransfer.Requests;
using Matemagicas.Application.Questions.DataTransfer.Responses;
using Matemagicas.Application.Utils.ValueObjects;

namespace Matemagicas.Application.Questions.Services.Interfaces;

public interface IQuestionsAppService
{
    Task<QuestionResponse> CreateAsync(QuestionCreateRequest request);
    Task<PagedResult<QuestionResponse>> GetAsync(QuestionPagedRequest request);
    Task<QuestionResponse> GetByIdAsync(string id);
    Task<QuestionResponse> UpdateAsync(string id, QuestionUpdateRequest request);
}
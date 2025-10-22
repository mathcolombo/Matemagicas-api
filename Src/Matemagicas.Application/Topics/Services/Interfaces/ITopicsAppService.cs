using Matemagicas.Application.Topics.DataTransfer.Requests;
using Matemagicas.Application.Topics.DataTransfer.Responses;
using Matemagicas.Application.Utils.ValueObjects;

namespace Matemagicas.Application.Topics.Services.Interfaces;

public interface ITopicsAppService
{
    Task<TopicResponse> CreateAsync(TopicCreateRequest request);
    Task<PagedResult<TopicResponse>> GetAsync(TopicPagedRequest request);
    Task<TopicResponse> GetByIdAsync(string id);
    Task<TopicResponse> UpdateAsync(string id, TopicUpdateRequest request);
}
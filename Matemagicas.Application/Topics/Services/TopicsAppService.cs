using Mapster;
using Matemagicas.Application.Topics.DataTransfer.Requests;
using Matemagicas.Application.Topics.DataTransfer.Responses;
using Matemagicas.Application.Topics.Services.Interfaces;
using Matemagicas.Application.Utils.Mappings;
using Matemagicas.Application.Utils.ValueObjects;
using Matemagicas.Domain.Topics.Entities;
using Matemagicas.Domain.Topics.Repositories.Filters;
using Matemagicas.Domain.Topics.Repositories.Interfaces;
using Matemagicas.Domain.Topics.Services.Commands;
using Matemagicas.Domain.Topics.Services.Interfaces;
using Matemagicas.Domain.Utils.Repositories.Interfaces;
using MongoDB.Bson;

namespace Matemagicas.Application.Topics.Services;

public class TopicsAppService(
    ITopicsRepository repository,
    ITopicsService service,
    IUnitOfWork unitOfWork) : ITopicsAppService
{
    public async Task<TopicResponse> CreateAsync(TopicCreateRequest request)
    {
        try
        {
            var command = request.Adapt<TopicCreateCommand>();
            var topic = await service.InstantiateAsync(command);
            
            await repository.CreateAsync(topic);
            await unitOfWork.SaveChangesAsync();
            
            return topic.Adapt<TopicResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<PagedResult<TopicResponse>> GetAsync(TopicPagedRequest request)
    {
        var filter = request.Adapt<TopicPagedFilter>();
        IQueryable<Topic> query = repository.Get(filter);
        var pagedTopics = await query.MapToPagedResult(request.PageNumber, request.PageSize);
        return pagedTopics.Adapt<PagedResult<TopicResponse>>();
    }

    public async Task<TopicResponse> GetByIdAsync(string id)
    {
        Topic topic = await service.ValidateAsync(ObjectId.Parse(id));
        return topic.Adapt<TopicResponse>();
    }

    public async Task<TopicResponse> UpdateAsync(string id, TopicUpdateRequest request)
    {
        try
        {
            var command = request.Adapt<TopicUpdateCommand>();
            var topic = await service.UpdateAsync(ObjectId.Parse(id), command);
            repository.Update(topic);
            return topic.Adapt<TopicResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
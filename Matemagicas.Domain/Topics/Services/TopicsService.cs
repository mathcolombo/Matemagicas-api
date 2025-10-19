using Matemagicas.Domain.Topics.Entities;
using Matemagicas.Domain.Topics.Repositories.Interfaces;
using Matemagicas.Domain.Topics.Services.Commands;
using Matemagicas.Domain.Topics.Services.Interfaces;
using MongoDB.Bson;

namespace Matemagicas.Domain.Topics.Services;

public class TopicsService(ITopicsRepository repository) : ITopicsService
{
    public async Task<Topic> InstantiateAsync(TopicCreateCommand command) => 
        await Task.FromResult(new Topic(command.Title, command.Description, command.Series));
    
    public async Task<Topic> ValidateAsync(ObjectId id) =>
        await repository.GetByIdAsync(id) ?? throw new Exception("Topic not found!");

    public async Task<Topic> UpdateAsync(ObjectId id, TopicUpdateCommand command)
    {
        var topic = await ValidateAsync(id);
        
        topic.SetTitle(command.Title);
        topic.SetDescription(command.Description);
        topic.SetSeries(command.Series);
        
        return topic;
    }
}
using Matemagicas.Domain.Topics.Entities;
using Matemagicas.Domain.Topics.Services.Commands;
using MongoDB.Bson;

namespace Matemagicas.Domain.Topics.Services.Interfaces;

public interface ITopicsService
{
    Task<Topic> InstantiateAsync(TopicCreateCommand command);
    Task<Topic> ValidateAsync(ObjectId id);
    Task<Topic> UpdateAsync(ObjectId id, TopicUpdateCommand command);
}
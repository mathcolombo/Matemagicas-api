using Mapster;
using Matemagicas.Application.Topics.DataTransfer.Requests;
using Matemagicas.Application.Topics.DataTransfer.Responses;
using Matemagicas.Application.Utils.ValueObjects;
using Matemagicas.Domain.Topics.Entities;
using Matemagicas.Domain.Topics.Services.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Matemagicas.Application.Topics.DataTransfer.Mappings;

public static class TopicsMappingConfiguration
{
    public static void RegisterTopicsMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<Topic, TopicResponse>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id.ToString());
        
        TypeAdapterConfig<TopicCreateRequest, TopicCreateCommand>
            .NewConfig(); 
        
        TypeAdapterConfig<TopicCreateRequest, TopicCreateCommand>
            .NewConfig();
        
        TypeAdapterConfig<PagedResult<Topic>, PagedResult<TopicResponse>>
            .NewConfig();
    }
}
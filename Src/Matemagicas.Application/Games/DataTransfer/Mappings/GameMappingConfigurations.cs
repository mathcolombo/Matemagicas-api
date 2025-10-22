using Mapster;
using Matemagicas.Application.Games.DataTransfer.Requests;
using Matemagicas.Application.Games.DataTransfer.Responses;
using Matemagicas.Application.Utils.ValueObjects;
using Matemagicas.Domain.Games.Entities;
using Matemagicas.Domain.Games.Repositories.Filters;
using Matemagicas.Domain.Games.Services.Commands;
using Matemagicas.Domain.Utils.Extensions;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;

namespace Matemagicas.Application.Games.DataTransfer.Mappings;

public static class GameMappingConfigurations
{
    public static void RegisterGameMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<Game, GameResponse>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id.ToString())
            .Map(dest => dest.QuestionsIds, src => src.QuestionsIds.Select(s => s.ToString()))
            .Map(dest => dest.TopicsIds, src => src.TopicsIds.Select(t => t.ToString()));

        TypeAdapterConfig<GameCreateRequest, GameCreateCommand>
            .NewConfig()
            .Map(dest => dest.UserId, src => ObjectId.Parse(src.UserId));
        
        TypeAdapterConfig<GameSaveRequest, GameSaveCommand>
            .NewConfig();

        TypeAdapterConfig<GamePagedRequest, GamePagedFilter>
            .NewConfig()
            .Map(dest => dest.UserId, src => src.UserId.ToObjectIdOrNullable())
            .Map(dest => dest.QuestionsIds, src => (src.QuestionsIds ?? Array.Empty<string>()).Select(ObjectId.Parse));

        TypeAdapterConfig<PagedResult<Game>, PagedResult<GameResponse>>
            .NewConfig();
    }
}
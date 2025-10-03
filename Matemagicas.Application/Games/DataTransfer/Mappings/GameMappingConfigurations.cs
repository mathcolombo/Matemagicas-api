using Mapster;
using Matemagicas.Application.Games.DataTransfer.Requests;
using Matemagicas.Application.Games.DataTransfer.Responses;
using Matemagicas.Domain.Games.Entities;
using Matemagicas.Domain.Games.Services.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Matemagicas.Application.Games.DataTransfer.Mappings;

public static class GameMappingConfigurations
{
    public static void RegisterGameMaps(this IServiceCollection services)
    {
        TypeAdapterConfig<Game, GameResponse>
            .NewConfig()
            .Map(dest => dest.Id, src => src.Id.ToString());

        TypeAdapterConfig<GameCreateRequest, GameCreateCommand>
            .NewConfig();
        
        TypeAdapterConfig<GameSaveRequest, GameSaveCommand>
            .NewConfig();
    }
}
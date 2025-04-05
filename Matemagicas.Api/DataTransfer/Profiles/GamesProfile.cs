using AutoMapper;
using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Commands;

namespace Matemagicas.Api.DataTransfer.Profiles;

public class GamesProfile : Profile
{
    public GamesProfile()
    {
        CreateMap<Game, GameResponse>();

        CreateMap<GamePreloadRequest, GamePreloadCommand>();
        CreateMap<GameSaveRequest, GameSaveCommand>();
    }
}
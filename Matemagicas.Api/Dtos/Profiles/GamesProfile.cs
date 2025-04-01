using AutoMapper;
using Matemagicas.Api.Dtos.Responses;
using Matemagicas.Api.Entities;

namespace Matemagicas.Api.Dtos.Profiles;

public class GamesProfile : Profile
{
    public GamesProfile()
    {
        CreateMap<Game, GameResponse>();
    }
}
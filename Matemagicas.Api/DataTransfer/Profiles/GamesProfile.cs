using AutoMapper;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;

namespace Matemagicas.Api.DataTransfer.Profiles;

public class GamesProfile : Profile
{
    public GamesProfile()
    {
        CreateMap<Game, GameResponse>();
    }
}
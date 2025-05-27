using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Commands;
using Matemagicas.Api.Domain.Services.Filters;
using MongoDB.Bson;

namespace Matemagicas.Api.Domain.Services.Interfaces;

public interface IGamesService
{
    Game Preload(GamePreloadCommand command);
    Game Save(ObjectId id, GameSaveCommand command);
    IQueryable<Game> Get(GamePagedFilter filter);
    Game GetById(ObjectId id);
    Game Delete(ObjectId id);
}
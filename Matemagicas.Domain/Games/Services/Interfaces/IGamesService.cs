using Matemagicas.Domain.Games.Entities;
using Matemagicas.Domain.Games.Services.Commands;
using MongoDB.Bson;

namespace Matemagicas.Domain.Games.Services.Interfaces;

public interface IGamesService
{
    Game Preload(GamePreloadCommand command);
    Game Save(ObjectId id, GameSaveCommand command);
    // IQueryable<Game> Get(GamePagedFilter filter);
    Game GetById(ObjectId id);
    Game Delete(ObjectId id);
}
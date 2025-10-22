using Matemagicas.Domain.Games.Entities;
using Matemagicas.Domain.Games.Services.Commands;
using MongoDB.Bson;

namespace Matemagicas.Domain.Games.Services.Interfaces;

public interface IGamesService
{
    Task<Game> InstantiateAsync(GameCreateCommand command);
    Task<Game> SaveAsync(ObjectId id, GameSaveCommand command);
    // IQueryable<Game> Get(GamePagedFilter filter);
    Task<Game> ValidateAsync(ObjectId id);
    Task DeleteAsync(ObjectId id);
}
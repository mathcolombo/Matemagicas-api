using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Commands;

namespace Matemagicas.Api.Domain.Services.Interfaces;

public interface IGamesService
{
    Game Preload(GamePreloadCommand command);
    Game Save(int id, GameSaveCommand command);
    Game GetById(int id);
    Game Delete(int id);
}
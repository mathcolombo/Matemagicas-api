using Matemagicas.Api.Entities;
using Matemagicas.Api.Services.Commands;

namespace Matemagicas.Api.Services.Interfaces;

public interface IGamesService
{
    Game Preload(GamePreloadCommand command);
    Game Save(int id, GameSaveCommand command);
    Game GetById(int id);
    Game Delete(int id);
}
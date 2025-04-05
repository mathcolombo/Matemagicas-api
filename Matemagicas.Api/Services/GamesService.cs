using Matemagicas.Api.Entities;
using Matemagicas.Api.Repositories.Interfaces;
using Matemagicas.Api.Services.Commands;
using Matemagicas.Api.Services.Interfaces;

namespace Matemagicas.Api.Services;

public class GamesService : IGamesService
{
    private readonly IGamesRepository _gamesRepository;
    private readonly IUsersService _usersService;

    public GamesService(IGamesRepository gamesRepository, IUsersService usersService)
    {
        _gamesRepository = gamesRepository;
        _usersService = usersService;
    }

    public Game Instantiate(GamePreloadCommand command, IEnumerable<int> questions)
    {
        User user = _usersService.GetById(command.UserId);
        return new Game(command.UserId, questions);
    }
    
    public Game Preload(GamePreloadCommand command)
    {
        throw new NotImplementedException();
    }

    public Game Save(int id, GameSaveCommand command)
    {
        throw new NotImplementedException();
    }

    public Game GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Game Delete(int id)
    {
        throw new NotImplementedException();
    }
}
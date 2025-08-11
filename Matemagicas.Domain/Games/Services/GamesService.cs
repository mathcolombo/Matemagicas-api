using Matemagicas.Domain.Games.Entities;
using Matemagicas.Domain.Games.Repositories.Interfaces;
using Matemagicas.Domain.Games.Services.Commands;
using Matemagicas.Domain.Games.Services.Interfaces;
using Matemagicas.Domain.Questions.Services.Interfaces;
using Matemagicas.Domain.Users.Services.Interfaces;
using MongoDB.Bson;

namespace Matemagicas.Domain.Games.Services;

public class GamesService : IGamesService
{
    private readonly IGamesRepository _gamesRepository;
    private readonly IUsersService _usersService;
    private readonly IQuestionsService _questionsService;

    public GamesService(IGamesRepository gamesRepository,
                        IUsersService usersService,
                        IQuestionsService questionsService)
    {
        _gamesRepository = gamesRepository;
        _usersService = usersService;
        _questionsService = questionsService;
    }

    public Game Instantiate(GamePreloadCommand command, IEnumerable<ObjectId> questionsIds)
    {
        _usersService.GetById(command.UserId);
        
        return new Game(command.UserId, questionsIds, command.Topics);
    }
    
    public Game Preload(GamePreloadCommand command)
    {
        IEnumerable<ObjectId> questionsIds = _questionsService.GetByTopicsAndDifficulty(command.Topics, command.Difficulty, 10);
        Game game = Instantiate(command, questionsIds);
        return _gamesRepository.Create(game);
    }

    public Game Save(ObjectId id, GameSaveCommand command)
    {
        Game game = GetById(id);
        
        game.SetDate(DateTime.Now);
        game.SetScore(command.Score);
        game.SetCorrectAnswers(command.CorrectAnswers);
        game.SetIncorrectAnswers(command.IncorrectAnswers);
        
        _usersService.UpdatePlayerScore(game.UserId, command.Score);
        
        return _gamesRepository.Update(game);
    }
    
    // public IQueryable<Game> Get(GamePagedFilter filter) => _gamesRepository.Get(filter);

    public Game GetById(ObjectId id) => _gamesRepository.GetById(id) ?? throw new NullReferenceException("Game não encontrado!");

    public Game Delete(ObjectId id)
    {
        Game game = GetById(id);
        _gamesRepository.Delete(game);
        return game;
    }
}
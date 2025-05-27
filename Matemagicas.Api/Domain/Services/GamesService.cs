using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Commands;
using Matemagicas.Api.Domain.Services.Filters;
using Matemagicas.Api.Domain.Services.Interfaces;
using Matemagicas.Api.Domain.Utils.Entities;
using Matemagicas.Api.Infrastructure.Repositories.Interfaces;
using MongoDB.Bson;

namespace Matemagicas.Api.Domain.Services;

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
        IEnumerable<ObjectId> questionsIds = _questionsService.GetByTopicsAndDifficulty(command.Topics, command.Difficulty, StaticParameters.AMOUNT_OF_QUESTIONS_DEFAULT);
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
        
        _usersService.UpdatePlayerScore(game.Id, command.Score);
        
        return _gamesRepository.Update(game);
    }
    
    public IQueryable<Game> Get(GamePagedFilter filter) => _gamesRepository.Get(filter);

    public Game GetById(ObjectId id) => _gamesRepository.GetById(id) ?? throw new NullReferenceException("Game não encontrado!");

    public Game Delete(ObjectId id)
    {
        Game game = GetById(id);
        _gamesRepository.Delete(game);
        return game;
    }
}
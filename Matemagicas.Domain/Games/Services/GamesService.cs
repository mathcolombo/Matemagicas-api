using Matemagicas.Domain.Classes.Entities;
using Matemagicas.Domain.Classes.Services.Interfaces;
using Matemagicas.Domain.Games.Entities;
using Matemagicas.Domain.Games.Repositories.Interfaces;
using Matemagicas.Domain.Games.Services.Commands;
using Matemagicas.Domain.Games.Services.Interfaces;
using Matemagicas.Domain.Questions.Entities;
using Matemagicas.Domain.Questions.Services.Interfaces;
using Matemagicas.Domain.Users.Entities;
using Matemagicas.Domain.Users.Services.Interfaces;
using Matemagicas.Domain.Utils.Enums;
using MongoDB.Bson;

namespace Matemagicas.Domain.Games.Services;

public class GamesService : IGamesService
{
    private readonly IGamesRepository _repository;
    private readonly IUsersService _usersService;
    private readonly IQuestionsService _questionsService;
    private readonly IClassesService _classesService;

    public GamesService(IGamesRepository repository,
                        IUsersService usersService,
                        IQuestionsService questionsService,
                        IClassesService classesService)
    {
        _repository = repository;
        _usersService = usersService;
        _questionsService = questionsService;
        _classesService = classesService;
    }

    public async Task<Game> InstantiateAsync(GameCreateCommand command)
    {
        User user = await _usersService.ValidateAsync(command.UserId);
        Class classRoom = await _classesService.ValidateAsync(user.ClassId.Value);
        
        List<Question> questions = _questionsService.GetByTopics(classRoom.AllowedTopics, 10).ToList();
        
        var gameQuestionsData = GetGameQuestionsData(questions);
        
        return new Game(command.UserId,
            gameQuestionsData.questionIds,
            gameQuestionsData.topics,
            gameQuestionsData.averageDifficulty);
    }

    private static (IEnumerable<TopicEnum> topics, IEnumerable<ObjectId> questionIds, DifficultyEnum averageDifficulty) GetGameQuestionsData(IEnumerable<Question> questions)
    {
        List<Question> loadedQuestions = questions.ToList();
        
        IEnumerable<ObjectId> questionIds = loadedQuestions.Select(q => q.Id);
        
        IEnumerable<TopicEnum> topics = loadedQuestions.Select(q => q.Topic).Distinct();
        
        DifficultyEnum averageDifficulty = loadedQuestions.GroupBy(q => q.Difficulty)
            .OrderByDescending(g => g.Count())
            .First().Key;
        
        return (topics, questionIds, averageDifficulty);
    }

    public async Task<Game> SaveAsync(ObjectId id, GameSaveCommand command)
    {
        Game game = await ValidateAsync(id);
        
        game.SetDate(DateTime.Now);
        game.SetScore(command.Score);
        game.SetCorrectAnswers(command.CorrectAnswers);
        game.SetIncorrectAnswers(command.IncorrectAnswers);
        
        await _usersService.UpdatePlayerScoreAsync(game.UserId, command.Score);
        
        return _repository.Update(game);
    }
    
    // public IQueryable<Game> Get(GamePagedFilter filter) => _repository.Get(filter);

    public async Task<Game> ValidateAsync(ObjectId id) =>
        await _repository.GetByIdAsync(id) ?? throw new NullReferenceException("Game não encontrado!");

    public async Task DeleteAsync(ObjectId id)
    {
        Game game = await ValidateAsync(id);
        _repository.Delete(game);
    }
}
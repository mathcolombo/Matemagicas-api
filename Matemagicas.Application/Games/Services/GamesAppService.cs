using Mapster;
using Matemagicas.Application.Games.DataTransfer.Requests;
using Matemagicas.Application.Games.DataTransfer.Responses;
using Matemagicas.Application.Games.Services.Interfaces;
using Matemagicas.Domain.Games.Entities;
using Matemagicas.Domain.Games.Repositories.Interfaces;
using Matemagicas.Domain.Games.Services.Commands;
using Matemagicas.Domain.Games.Services.Interfaces;
using Matemagicas.Domain.Utils.Repositories.Interfaces;
using MongoDB.Bson;

namespace Matemagicas.Application.Games.Services;

public class GamesAppService : IGamesAppService
{
    private readonly IGamesRepository _repository;
    private readonly IGamesService _service;
    private readonly IUnitOfWork _unitOfWork;

    public GamesAppService(IGamesRepository repository, IGamesService service, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _service = service;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<GameResponse> CreateAsync(GameCreateRequest request)
    {
        try
        {
            var command = request.Adapt<GameCreateCommand>();
            Game game = await _service.InstantiateAsync(command);
            
            await _repository.CreateAsync(game);
            await _unitOfWork.SaveChangesAsync();
            
            return game.Adapt<GameResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<GameResponse> GetByIdAsync(string id)
    {
        Game game = await _service.ValidateAsync(ObjectId.Parse(id));
        return game.Adapt<GameResponse>();
    }

    public async Task<GameResponse> SaveAsync(string id, GameSaveRequest request)
    {
        try
        {
            GameSaveCommand command = request.Adapt<GameSaveCommand>();
            Game game = await _service.SaveAsync(ObjectId.Parse(id), command);
            
            _repository.Update(game);
            await _unitOfWork.SaveChangesAsync();
            
            return game.Adapt<GameResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
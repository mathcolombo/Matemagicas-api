using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Application.Games.DataTransfer.Mappings;
using Matemagicas.Application.Games.DataTransfer.Requests;
using Matemagicas.Application.Utils.Mappings;
using Matemagicas.Application.Utils.ValueObjects;
using Matemagicas.Domain.Games.Entities;
using Matemagicas.Domain.Games.Services.Interfaces;
using Matemagicas.Infrastructure.Utils.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Matemagicas.Api.Controllers;

[ApiController]
[Route("api/games")]
public class GamesController : Controller
{
    private readonly IGamesService _gamesService;
    private readonly IUnitOfWork _unitOfWork;

    public GamesController(IGamesService gamesService,
                        IUnitOfWork unitOfWork)
    {
        _gamesService = gamesService;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Creates a pre-game with the necessary data for the user to play
    /// </summary>
    /// <param name="request"></param>
    /// <returns>GameResponse</returns>
    [HttpPost]
    public ActionResult<GameResponse> Preload([FromBody] GamePreloadRequest request)
    {
        var command = request.MapToGamePreloadCommand();
        
        Game game = _gamesService.Preload(command);
        _unitOfWork.SaveChanges();

        var response = game.MapToGameResponse();
        return Ok(response);
    }

    // /// <summary>
    // /// List all games
    // /// </summary>
    // /// <param name="request"></param>
    // /// <param name="pageNumber"></param>
    // /// <param name="pageSize"></param>
    // /// <returns>PagedResult</returns>
    // [HttpGet]
    // public ActionResult<PagedResult<GameResponse>> Get([FromQuery] GamePagedRequest request, [FromQuery] int pageNumber, [FromQuery] int pageSize)
    // {
    //     var filter = request.MapToGamePagedFilter();
    //     
    //     IQueryable<Game> games = _gamesService.Get(filter);
    //     var response = games.MapToPagedResult(q => q.MapToGameResponse(), pageNumber, pageSize);
    //     
    //     return Ok(response);
    // }
    
    /// <summary>
    /// Retrieves a game based on its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>GameResponse</returns>
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<GameResponse>> GetById(string id)
    {
        var objectId = ObjectId.Parse(id);
        
        Game game = _gamesService.GetById(objectId);
        
        var response = game.MapToGameResponse();
        return Ok(response);
    }
    
    /// <summary>
    /// Saves the game after the user plays
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns>GameResponse</returns>
    [HttpPut("{id}")]
    public ActionResult<GameResponse> Save(string id, [FromBody] GameSaveRequest request)
    {
        var objectId = ObjectId.Parse(id);
        var command = request.MapToGameSaveCommand();
        
        Game game = _gamesService.Save(objectId, command);
        _unitOfWork.SaveChanges();
        
        var response = game.MapToGameResponse();
        return Ok(response);
    }
}
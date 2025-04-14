using AutoMapper;

using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Extensions;
using Matemagicas.Api.Domain.Services.Commands;
using Matemagicas.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Matemagicas.Api.Controllers;

[ApiController]
[Route("api/games")]
public class GamesController : Controller
{
    private readonly IGamesService _gamesService;
    private readonly IMapper _mapper;

    public GamesController(IGamesService gamesService, IMapper mapper)
    {
        _gamesService = gamesService;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a pre-game with the necessary data for the user to play
    /// </summary>
    /// <param name="request"></param>
    /// <returns>GameResponse</returns>
    [HttpPost]
    public ActionResult<GameResponse> Preload([FromBody] GamePreloadRequest request)
    {
        var command = _mapper.Map<GamePreloadCommand>(request);
        
        Game game = _gamesService.Preload(command);

        var response = game.MapToGameResponse();
        return Ok(response);
    }

    /// <summary>
    /// List all games
    /// </summary>
    /// <returns>GameResponse</returns>
    [HttpGet]
    public ActionResult<IEnumerable<GameResponse>> GetAll()
    {
        return Ok();
    }
    
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
        var command = _mapper.Map<GameSaveCommand>(request);
        
        Game game = _gamesService.Save(objectId, command);
        
        var response = game.MapToGameResponse();
        return Ok(response);
    }
}
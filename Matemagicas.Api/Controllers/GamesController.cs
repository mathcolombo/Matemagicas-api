using Matemagicas.Api.Services.Interfaces;
using Matemagicas.Api.Dtos.Requests;
using Matemagicas.Api.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Matemagicas.Api.Controllers;

[ApiController]
[Route("api/games")]
public class GamesController(IGamesService gamesService) : Controller
{
    private readonly IGamesService _gamesService = gamesService;

    /// <summary>
    /// Creates a pre-game with the necessary data for the user to play
    /// </summary>
    /// <param name="request"></param>
    /// <returns>GameResponse</returns>
    [HttpPost]
    public ActionResult<GameResponse> Preload([FromBody] GamePreloadRequest request)
    {
        return Ok();
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
    [HttpGet("{id:int}")]
    public ActionResult<IEnumerable<GameResponse>> GetById(int id)
    {
        return Ok();
    }
    
    /// <summary>
    /// Saves the game after the user plays
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns>GameResponse</returns>
    [HttpPut("{id:int}")]
    public ActionResult<GameResponse> Save(int id, [FromBody] GameSaveRequest request)
    {
        return Ok();
    }
}
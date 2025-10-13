using Matemagicas.Application.Games.DataTransfer.Requests;
using Matemagicas.Application.Games.DataTransfer.Responses;
using Matemagicas.Application.Games.Services.Interfaces;
using Matemagicas.Application.Utils.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Matemagicas.Api.Controllers.Games;

[ApiController]
[Route("api/games")]
public class GamesController(IGamesAppService gamesAppService) : ControllerBase
{
    /// <summary>
    /// Creates a pre-game with the necessary data for the user to play
    /// </summary>
    /// <param name="request"></param>
    /// <returns>GameResponse</returns>
    [HttpPost]
    public async Task<ActionResult<GameResponse>> CreateAsync([FromBody] GameCreateRequest request) =>
    Ok(await gamesAppService.CreateAsync(request));
    
    /// <summary>
    /// List all games
    /// </summary>
    /// <param name="request"></param>
    /// <returns>PagedResult GameResponse</returns>
    [HttpGet]
    public async Task<ActionResult<PagedResult<GameResponse>>> GetAsync([FromQuery] GamePagedRequest request) =>
        Ok(await gamesAppService.GetAsync(request));
    
    /// <summary>
    /// Retrieves a game based on its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>GameResponse</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<GameResponse>> GetByIdAsync(string id) =>
        Ok(await gamesAppService.GetByIdAsync(id));
    
    /// <summary>
    /// Saves the game after the user plays
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns>GameResponse</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<GameResponse>> SaveAsync(string id, [FromBody] GameSaveRequest request) =>
    Ok(await gamesAppService.SaveAsync(id, request));
}
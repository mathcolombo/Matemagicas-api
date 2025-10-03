using Matemagicas.Application.Games.DataTransfer.Requests;
using Matemagicas.Application.Games.DataTransfer.Responses;
using Matemagicas.Application.Games.Services.Interfaces;
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
    //     IQueryable<Game> games = gamesAppService.Get(filter);
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
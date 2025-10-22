using Matemagicas.Application.Topics.DataTransfer.Requests;
using Matemagicas.Application.Topics.DataTransfer.Responses;
using Matemagicas.Application.Topics.Services.Interfaces;
using Matemagicas.Application.Utils.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Matemagicas.Api.Controllers.Topics;

[ApiController]
[Route("api/topics")]
public class TopicsController(ITopicsAppService topicsAppService) : ControllerBase
{
    /// <summary>
    /// Creates a topic
    /// </summary>
    /// <param name="request"></param>
    /// <returns>TopicResponse</returns>
    [HttpPost]
    public async Task<ActionResult<TopicResponse>> CreateAsync([FromBody] TopicCreateRequest request) =>
        Ok(await topicsAppService.CreateAsync(request));
    
    /// <summary>
    /// List all topics
    /// </summary>
    /// <param name="request"></param>
    /// <returns>PagedResult TopicResponse</returns>
    [HttpGet]
    public async Task<ActionResult<PagedResult<TopicResponse>>> GetAsync([FromQuery] TopicPagedRequest request) =>
        Ok(await topicsAppService.GetAsync(request));
    
    /// <summary>
    /// Retrieves a game based on its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>TopicResponse</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TopicResponse>> GetByIdAsync(string id) =>
        Ok(await topicsAppService.GetByIdAsync(id));
    
    /// <summary>
    /// Update the game
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns>TopicResponse</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<TopicResponse>> UpdateAsync(string id, [FromBody] TopicUpdateRequest request) =>
        Ok(await topicsAppService.UpdateAsync(id, request));
}
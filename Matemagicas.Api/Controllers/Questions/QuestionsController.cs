using Matemagicas.Application.Questions.DataTransfer.Requests;
using Matemagicas.Application.Questions.DataTransfer.Responses;
using Matemagicas.Application.Questions.Services.Interfaces;
using Matemagicas.Application.Utils.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Matemagicas.Api.Controllers.Questions;

[ApiController]
[Route("api/questions")]
public class QuestionsController(IQuestionsAppService questionsAppService) : ControllerBase
{
    /// <summary>
    /// Creates a Question
    /// </summary>
    /// <param name="request"></param>
    /// <returns>QuestionResponse</returns>
    [HttpPost]
    public async Task<ActionResult<QuestionResponse>> CreateAsync([FromBody] QuestionCreateRequest request) =>
        Ok(await questionsAppService.CreateAsync(request));
    
    /// <summary>
    /// List all questions
    /// </summary>
    /// <param name="request"></param>
    /// <returns>PagedResult QuestionResponse</returns>
    [HttpGet]
    public async Task<ActionResult<PagedResult<QuestionResponse>>> GetAsync([FromQuery] QuestionPagedRequest request) =>
        Ok(await questionsAppService.GetAsync(request));

    /// <summary>
    /// Retrieves a Question based on its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>QuestionResponse</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<QuestionResponse>> GetByIdAsync(string id) =>
        Ok(await questionsAppService.GetByIdAsync(id));
    
    /// <summary>
    /// Retrieves a Question based on its id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns>QuestionResponse</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<QuestionResponse>> UpdateAsync(string id, [FromBody] QuestionUpdateRequest request) =>
        Ok(await questionsAppService.UpdateAsync(id, request));
}
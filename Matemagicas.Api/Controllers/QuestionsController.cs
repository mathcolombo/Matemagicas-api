using Matemagicas.Api.Domain.Services.Interfaces;
using Matemagicas.Api.Dtos.Requests;
using Matemagicas.Api.Dtos.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Matemagicas.Api.Controllers;

[ApiController]
[Route("api/questions")]
public class QuestionsController(IQuestionsService questionsService) : Controller
{
    private readonly IQuestionsService _questionsService = questionsService;

    /// <summary>
    /// Create a question
    /// </summary>
    /// <param name="request"></param>
    /// <returns>QuestionResponse</returns>
    [HttpPost]
    public ActionResult<QuestionResponse> Create([FromBody] QuestionCreateRequest request)
    {
        return Ok();
    }
    
    /// <summary>
    /// List all questions
    /// </summary>
    /// <returns>QuestionResponse</returns>
    [HttpGet]
    public ActionResult<QuestionResponse> GetAll()
    {
        return Ok();
    }
    
    /// <summary>
    /// Retrieves a question based on its id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>QuestionResponse</returns>
    [HttpGet("{id:int}")]
    public ActionResult<QuestionResponse> GetById(int id)
    {
        return Ok();
    }
    
    /// <summary>
    /// Update a question
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns>QuestionResponse</returns>
    [HttpPut("{id:int}")]
    public ActionResult<QuestionResponse> Update(int id, [FromBody] QuestionCreateRequest request)
    {
        return Ok();
    }    
    
    /// <summary>
    /// Logically delete a question
    /// </summary>
    /// <param name="id"></param>
    /// <returns>QuestionResponse</returns>
    [HttpDelete("{id:int}")]
    public ActionResult<QuestionResponse> Delete(int id)
    {
        return Ok();
    }
}
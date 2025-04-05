using AutoMapper;
using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Commands;
using Matemagicas.Api.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Matemagicas.Api.Controllers;

[ApiController]
[Route("api/questions")]
public class QuestionsController : Controller
{
    private readonly IQuestionsService _questionsService;
    private readonly IMapper _mapper;

    public QuestionsController(IQuestionsService questionsService, IMapper mapper)
    {
        _questionsService = questionsService;
        _mapper = mapper;
    }

    /// <summary>
    /// Create a question
    /// </summary>
    /// <param name="request"></param>
    /// <returns>QuestionResponse</returns>
    [HttpPost]
    public ActionResult<QuestionResponse> Create([FromBody] QuestionCreateRequest request)
    {
        var command = _mapper.Map<QuestionCreateCommand>(request);
        Question question = _questionsService.Create(command);
        var response = _mapper.Map<QuestionResponse>(question);
        return Ok(response);
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
        Question question = _questionsService.GetById(id);
        var response = _mapper.Map<QuestionResponse>(question);
        return Ok(response);
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
        var command = _mapper.Map<QuestionUpdateCommand>(request);
        Question question = _questionsService.Update(id, command);
        var response = _mapper.Map<QuestionResponse>(question);
        return Ok(response);
    }    
    
    /// <summary>
    /// Logically delete a question
    /// </summary>
    /// <param name="id"></param>
    /// <returns>QuestionResponse</returns>
    [HttpDelete("{id:int}")]
    public ActionResult<QuestionResponse> Inactive(int id)
    {
        Question question = _questionsService.Inactive(id);
        var response = _mapper.Map<QuestionResponse>(question);
        return Ok(response);
    }
}
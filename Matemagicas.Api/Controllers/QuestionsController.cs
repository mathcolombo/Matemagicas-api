using AutoMapper;
using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Extensions;
using Matemagicas.Api.Domain.Services.Commands;
using Matemagicas.Api.Domain.Services.Interfaces;
using Matemagicas.Api.Infrastructure.Utils.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Matemagicas.Api.Controllers;

[ApiController]
[Route("api/questions")]
public class QuestionsController : Controller
{
    private readonly IQuestionsService _questionsService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public QuestionsController(IQuestionsService questionsService, 
                            IMapper mapper,
                            IUnitOfWork unitOfWork)
    {
        _questionsService = questionsService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
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
        _unitOfWork.SaveChanges();
        
        var response = question.MapToQuestionResponse();
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
    [HttpGet("{id}")]
    public ActionResult<QuestionResponse> GetById(string id)
    {
        var objectId = ObjectId.Parse(id);
        
        Question question = _questionsService.GetById(objectId);

        var response = question.MapToQuestionResponse();
        return Ok(response);
    }
    
    /// <summary>
    /// Update a question
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns>QuestionResponse</returns>
    [HttpPut("{id}")]
    public ActionResult<QuestionResponse> Update(string id, [FromBody] QuestionCreateRequest request)
    {
        var objectId = ObjectId.Parse(id);
        var command = _mapper.Map<QuestionUpdateCommand>(request);
        
        Question question = _questionsService.Update(objectId, command);
        _unitOfWork.SaveChanges();
        
        var response = question.MapToQuestionResponse();
        return Ok(response);
    }    
    
    /// <summary>
    /// Logically delete a question
    /// </summary>
    /// <param name="id"></param>
    /// <returns>QuestionResponse</returns>
    [HttpDelete("{id}")]
    public ActionResult<QuestionResponse> Inactive(string id)
    {
        var objectId = ObjectId.Parse(id);
        
        Question question = _questionsService.Inactive(objectId);
        _unitOfWork.SaveChanges();
        
        var response = question.MapToQuestionResponse();
        return Ok(response);
    }
}
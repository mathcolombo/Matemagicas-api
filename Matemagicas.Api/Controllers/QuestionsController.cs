using Matemagicas.Api.DataTransfer.Mappings;
using Matemagicas.Api.DataTransfer.Requests;
using Matemagicas.Api.DataTransfer.Responses;
using Matemagicas.Api.DataTransfer.Utils.Mappings;
using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Domain.Services.Interfaces;
using Matemagicas.Api.Domain.Utils.Entities;
using Matemagicas.Api.Infrastructure.Utils.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Matemagicas.Api.Controllers;

[ApiController]
[Route("api/questions")]
public class QuestionsController : Controller
{
    private readonly IQuestionsService _questionsService;
    private readonly IUnitOfWork _unitOfWork;

    public QuestionsController(IQuestionsService questionsService, 
                            IUnitOfWork unitOfWork)
    {
        _questionsService = questionsService;
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
        var command = request.MapToQuestionCreateCommand();
        
        Question question = _questionsService.Create(command);
        _unitOfWork.SaveChanges();
        
        var response = question.MapToQuestionResponse();
        return Ok(response);
    }
    
    /// <summary>
    /// List all questions
    /// </summary>
    /// <param name="request"></param>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns>PagedResult</returns>
    [HttpGet]
    public ActionResult<PagedResult<QuestionResponse>> Get([FromQuery] QuestionsPagedRequest request, [FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        var filter = request.MapToGamePagedFilter();
        
        IQueryable<Question> questions = _questionsService.Get(filter);
        var response = questions.MapToPagedResult(q => q.MapToQuestionResponse(), pageNumber, pageSize);
        
        return Ok(response);
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
    public ActionResult<QuestionResponse> Update(string id, [FromBody] QuestionUpdateRequest request)
    {
        var objectId = ObjectId.Parse(id);
        var command = request.MapToQuestionUpdateCommand();
        
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
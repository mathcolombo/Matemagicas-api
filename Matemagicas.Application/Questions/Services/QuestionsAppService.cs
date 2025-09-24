using Mapster;
using Matemagicas.Application.Questions.DataTransfer.Requests;
using Matemagicas.Application.Questions.DataTransfer.Responses;
using Matemagicas.Application.Questions.Services.Interfaces;
using Matemagicas.Domain.Questions.Entities;
using Matemagicas.Domain.Questions.Repositories.Interfaces;
using Matemagicas.Domain.Questions.Services.Commands;
using Matemagicas.Domain.Questions.Services.Interfaces;
using Matemagicas.Domain.Utils.Repositories.Interfaces;
using MongoDB.Bson;

namespace Matemagicas.Application.Questions.Services;

public class QuestionsAppService : IQuestionsAppService
{
    private readonly IQuestionsRepository _repository;
    private readonly IQuestionsService _service;
    private readonly IUnitOfWork _unitOfWork;

    public QuestionsAppService(IQuestionsRepository repository, IQuestionsService service, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _service = service;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<QuestionResponse> CreateAsync(QuestionCreateRequest request)
    {
        try
        {
            var command = request.Adapt<QuestionCreateCommand>();
            Question question = await _service.InstantiateAsync(command);
            
            await _repository.CreateAsync(question);
            await _unitOfWork.SaveChangesAsync();
            
            return question.Adapt<QuestionResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<QuestionResponse> GetByIdAsync(string id)
    {
        Question question = await _service.ValidateAsync(ObjectId.Parse(id));
        return question.Adapt<QuestionResponse>();
    }

    public async Task<QuestionResponse> UpdateAsync(string id, QuestionUpdateRequest request)
    {
        try
        {
            QuestionUpdateCommand command = request.Adapt<QuestionUpdateCommand>();
            Question question = await _service.UpdateAsync(ObjectId.Parse(id), command);
            
            _repository.Update(question);
            await _unitOfWork.SaveChangesAsync();
            
            return question.Adapt<QuestionResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            Question question = await _service.ValidateAsync(ObjectId.Parse(id));
            _repository.Delete(question);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
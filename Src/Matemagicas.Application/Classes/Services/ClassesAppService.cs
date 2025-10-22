using Mapster;
using Matemagicas.Application.Classes.DataTransfer.Requests;
using Matemagicas.Application.Classes.DataTransfer.Responses;
using Matemagicas.Application.Classes.Services.Interfaces;
using Matemagicas.Application.Utils.Mappings;
using Matemagicas.Application.Utils.ValueObjects;
using Matemagicas.Domain.Classes.Entities;
using Matemagicas.Domain.Classes.Repositories.Filters;
using Matemagicas.Domain.Classes.Repositories.Interfaces;
using Matemagicas.Domain.Classes.Services.Commands;
using Matemagicas.Domain.Classes.Services.Interfaces;
using Matemagicas.Domain.Utils.Repositories.Interfaces;
using MongoDB.Bson;

namespace Matemagicas.Application.Classes.Services;

public class ClassesAppService : IClassesAppService
{
    private readonly IClassesRepository _repository;
    private readonly IClassesService _service;
    private readonly IUnitOfWork _unitOfWork;

    public ClassesAppService(IClassesRepository repository, IClassesService service, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _service = service;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ClassResponse> CreateAsync(ClassCreateRequest request)
    {
        try
        {
            var command = request.Adapt<ClassCreateCommand>();
            Class classRoom = await _service.InstantiateAsync(command);
            
            await _repository.CreateAsync(classRoom);
            await _unitOfWork.SaveChangesAsync();
            
            return classRoom.Adapt<ClassResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<PagedResult<ClassResponse>> GetAsync(ClassPagedRequest request)
    {
        var filter = request.Adapt<ClassPagedFilter>();
        var query = _repository.Get(filter);
        
        var pagedClasses = await query.MapToPagedResult(request.PageNumber, request.PageSize);
        return pagedClasses.Adapt<PagedResult<ClassResponse>>();
    }

    public async Task<ClassResponse> GetByIdAsync(string id)
    {
        Class classRoom = await _service.ValidateAsync(ObjectId.Parse(id));
        return classRoom.Adapt<ClassResponse>();
    }

    public async Task<ClassResponse> UpdateAsync(string id, ClassUpdateRequest request)
    {
        try
        {
            ClassUpdateCommand command = request.Adapt<ClassUpdateCommand>();
            Class classRoom = await _service.UpdateAsync(ObjectId.Parse(id), command);
            
            _repository.Update(classRoom);
            await _unitOfWork.SaveChangesAsync();
            
            return classRoom.Adapt<ClassResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<ClassResponse> InactivateAsync(string id)
    {
        try
        {
            Class classRoom = await _service.InactivateAsync(ObjectId.Parse(id));
            
            _repository.Update(classRoom);
            await _unitOfWork.SaveChangesAsync();
            
            return classRoom.Adapt<ClassResponse>();
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
            Class classRoom = await _service.ValidateAsync(ObjectId.Parse(id));
            _repository.Delete(classRoom);
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
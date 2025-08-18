using Mapster;
using Matemagicas.Application.Schools.DataTransfer.Requests;
using Matemagicas.Application.Schools.DataTransfer.Responses;
using Matemagicas.Application.Schools.Services.Interfaces;
using Matemagicas.Domain.Schools.Entities;
using Matemagicas.Domain.Schools.Repositories.Interfaces;
using Matemagicas.Domain.Schools.Services.Commands;
using Matemagicas.Domain.Schools.Services.Interfaces;
using Matemagicas.Domain.Utils.Repositories.Interfaces;
using MongoDB.Bson;

namespace Matemagicas.Application.Schools.Services;

public class SchoolsAppService : ISchoolsAppService
{
    private readonly ISchoolsRepository _repository;
    private readonly ISchoolsService _service;
    private readonly IUnitOfWork _unitOfWork;

    public SchoolsAppService(ISchoolsRepository repository, ISchoolsService service, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _service = service;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<SchoolResponse> CreateAsync(SchoolCreateRequest request)
    {
        try
        {
            SchoolCreateCommand command = request.Adapt<SchoolCreateCommand>();
            School school = _service.Instantiate(command);
            
            await _repository.CreateAsync(school);
            await _unitOfWork.SaveChangesAsync();
            
            return school.Adapt<SchoolResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    // public Task<PagedResult<School>> Get()
    // {
    //        
    // }

    public async Task<SchoolResponse> GetByIdAsync(string id)
    {
        School school = await _service.Validate(ObjectId.Parse(id));
        return school.Adapt<SchoolResponse>(); 
    }
}
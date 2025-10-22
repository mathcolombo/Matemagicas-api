using Matemagicas.Application.Schools.DataTransfer.Requests;
using Matemagicas.Application.Schools.DataTransfer.Responses;
using Matemagicas.Application.Utils.ValueObjects;

namespace Matemagicas.Application.Schools.Services.Interfaces;

public interface ISchoolsAppService
{
    Task<SchoolResponse> CreateAsync(SchoolCreateRequest request);
    Task<PagedResult<SchoolResponse>> GetAsync(SchoolPagedRequest request);
    Task<SchoolResponse> GetByIdAsync(string id);
    
}
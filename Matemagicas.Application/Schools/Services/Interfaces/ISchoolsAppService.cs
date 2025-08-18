using Matemagicas.Application.Schools.DataTransfer.Requests;
using Matemagicas.Application.Schools.DataTransfer.Responses;

namespace Matemagicas.Application.Schools.Services.Interfaces;

public interface ISchoolsAppService
{
    Task<SchoolResponse> CreateAsync(SchoolCreateRequest request);
    Task<SchoolResponse> GetByIdAsync(string id);
}
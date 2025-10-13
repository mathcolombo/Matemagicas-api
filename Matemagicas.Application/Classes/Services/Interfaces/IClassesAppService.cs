using Matemagicas.Application.Classes.DataTransfer.Requests;
using Matemagicas.Application.Classes.DataTransfer.Responses;
using Matemagicas.Application.Utils.ValueObjects;

namespace Matemagicas.Application.Classes.Services.Interfaces;

public interface IClassesAppService
{
    Task<ClassResponse> CreateAsync(ClassCreateRequest request);
    Task<PagedResult<ClassResponse>> GetAsync(ClassPagedRequest request);
    Task<ClassResponse> GetByIdAsync(string id);
    Task<ClassResponse> UpdateAsync(string id, ClassUpdateRequest request);
    Task<ClassResponse> InactivateAsync(string id);
    Task DeleteAsync(string id);
}
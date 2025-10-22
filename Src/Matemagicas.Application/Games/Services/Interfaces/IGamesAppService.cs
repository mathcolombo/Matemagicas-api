using Matemagicas.Application.Games.DataTransfer.Requests;
using Matemagicas.Application.Games.DataTransfer.Responses;
using Matemagicas.Application.Utils.ValueObjects;

namespace Matemagicas.Application.Games.Services.Interfaces;

public interface IGamesAppService
{
    Task<GameResponse> CreateAsync(GameCreateRequest request);
    Task<PagedResult<GameResponse>> GetAsync(GamePagedRequest request);
    Task<GameResponse> GetByIdAsync(string id);
    Task<GameResponse> SaveAsync(string id, GameSaveRequest request);
}
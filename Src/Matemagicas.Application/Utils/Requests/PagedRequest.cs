namespace Matemagicas.Application.Utils.Requests;

public record PagedRequest
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}
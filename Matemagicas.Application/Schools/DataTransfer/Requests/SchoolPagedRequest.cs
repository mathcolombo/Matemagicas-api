namespace Matemagicas.Application.Schools.DataTransfer.Requests;

public record SchoolPagedRequest(
    string? Name,
    AddressPagedRequest? Address,
    string? Phone,
    int PageNumber,
    int PageSize
);
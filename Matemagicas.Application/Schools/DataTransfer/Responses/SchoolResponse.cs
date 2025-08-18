namespace Matemagicas.Application.Schools.DataTransfer.Responses;

public record SchoolResponse(string Id,
    string Name,
    AddressResponse Address,
    string Phone);
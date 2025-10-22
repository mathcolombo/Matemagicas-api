using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Application.Schools.DataTransfer.Responses;

public record AddressResponse(StateEnum State,
    string City,
    string Neighborhood,
    string Street,
    string ZipCode,
    string? Number);
using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Application.Schools.DataTransfer.Requests;

public record AddressRequest(
    StateEnum State,
    string City,
    string Neighborhood,
    string Street,
    string ZipCode,
    string? Number
);
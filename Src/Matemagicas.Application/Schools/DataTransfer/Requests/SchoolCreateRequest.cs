namespace Matemagicas.Application.Schools.DataTransfer.Requests;

public record SchoolCreateRequest(
    string Name,
    AddressRequest Address,
    string Phone
);
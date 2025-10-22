using Matemagicas.Domain.Schools.Entities.ValueObjects;

namespace Matemagicas.Domain.Schools.Services.Commands;

public class SchoolCreateCommand
{
    public string Name { get; set; }
    public AddressCommand Address { get; set; }
    public string Phone { get; set; }
}
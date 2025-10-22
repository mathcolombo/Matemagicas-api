using Matemagicas.Domain.Utils.Enums;

namespace Matemagicas.Domain.Schools.Services.Commands;

public class AddressCommand
{
    public StateEnum State { get; set; }
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public string Street { get; set; }
    public string ZipCode { get; set; }
    public string? Number { get; set; }
}
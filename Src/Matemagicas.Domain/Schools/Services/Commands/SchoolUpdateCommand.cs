namespace Matemagicas.Domain.Schools.Services.Commands;

public class SchoolUpdateCommand
{
    public string Name { get; set; }
    public AddressCommand Address { get; set; }
    public string Phone { get; set; }
}
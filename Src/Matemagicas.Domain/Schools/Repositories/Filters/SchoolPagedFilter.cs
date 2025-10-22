using Matemagicas.Domain.Schools.Entities.ValueObjects;

namespace Matemagicas.Domain.Schools.Repositories.Filters;

public class SchoolPagedFilter
{
    public string? Name { get; set; }
    public Address? Address { get; set; }
    public string? Phone { get; set; }
}
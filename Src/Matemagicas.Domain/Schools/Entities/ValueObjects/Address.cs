using Matemagicas.Domain.Utils.Enums;
using Matemagicas.Domain.Utils.Extensions;

namespace Matemagicas.Domain.Schools.Entities.ValueObjects;

public class Address
{
    public StateEnum State { get; private set; }
    public string City { get; private set; }
    public string Neighborhood { get; private set; }
    public string Street { get; private set; }
    public string ZipCode { get; private set; }
    public string? Number { get; private set; }

    public Address(StateEnum state,
        string city,
        string neighborhood,
        string street,
        string zipCode,
        string? number)
    {
        State = state;
        SetCity(city);
        SetNeighborhood(neighborhood);
        SetStreet(street);
        SetZipCode(zipCode);
        SetNumber(number);
    }

    private void SetCity(string city)
    {
        const int minLength = 3;
        const int maxLength = 50;
        
        city.ValidateProperty(minLength, maxLength);
        
        City = city;
    }

    private void SetNeighborhood(string neighborhood)
    {
        const int minLength = 3;
        const int maxLength = 50;
        
        neighborhood.ValidateProperty(minLength, maxLength);
        
        Neighborhood = neighborhood;
    }

    private void SetStreet(string street)
    {
        const int minLength = 3;
        const int maxLength = 50;
        
        street.ValidateProperty(minLength, maxLength);
        
        Street = street;
    }

    private void SetZipCode(string zipCode)
    {
        const int minLength = 3;
        const int maxLength = 50;
        
        zipCode.ValidateProperty(minLength, maxLength);
        
        ZipCode = zipCode;
    }

    private void SetNumber(string? number)
    {
        const int minLength = 3;
        const int maxLength = 50;
        
        number?.ValidateProperty(minLength, maxLength);
        
        Number = number;
    }
}
using Matemagicas.Domain.Schools.Entities.ValueObjects;
using Matemagicas.Domain.Utils.Extensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Matemagicas.Domain.Schools.Entities;

public class School
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; protected set; }
    public string Name { get; protected set; }
    public Address Address { get; private set; }
    public string Phone { get; protected set; }
    
    public School() {}

    public School(string name, Address address, string phone)
    {
        SetName(name);
        Address = address;
        SetPhone(phone);
    }

    public void SetName(string name)
    {
        const int minLength = 3;
        const int maxLength = 50;
        
        name.ValidateProperty(minLength, maxLength);
        
        Name = name;
    }

    public void SetPhone(string phone)
    {
        const int minLength = 3;
        const int maxLength = 50;
        
        phone.ValidateProperty(minLength, maxLength);
        
        Phone = phone;
    }
}
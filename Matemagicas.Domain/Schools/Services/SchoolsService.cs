using Matemagicas.Domain.Schools.Entities;
using Matemagicas.Domain.Schools.Entities.ValueObjects;
using Matemagicas.Domain.Schools.Repositories.Interfaces;
using Matemagicas.Domain.Schools.Services.Commands;
using Matemagicas.Domain.Schools.Services.Interfaces;
using MongoDB.Bson;

namespace Matemagicas.Domain.Schools.Services;

public class SchoolsService : ISchoolsService
{
    private readonly ISchoolsRepository _repository;

    public SchoolsService(ISchoolsRepository repository)
    {
        _repository = repository;
    }

    public School Instantiate(SchoolCreateCommand command) =>
        new(command.Name,
            InstantiateAddress(command.Address),
            command.Phone);

    private static Address InstantiateAddress(AddressCommand command) =>
        new(command.State,
            command.City,
            command.Neighborhood,
            command.Street,
            command.ZipCode,
            command.Number);

    public async Task<School> Validate(ObjectId id) =>
        await _repository.GetByIdAsync(id) ?? throw new Exception("School not found");
}
using Matemagicas.Domain.Schools.Entities;
using Matemagicas.Domain.Schools.Services.Commands;
using MongoDB.Bson;

namespace Matemagicas.Domain.Schools.Services.Interfaces;

public interface ISchoolsService
{
    School Instantiate(SchoolCreateCommand command);
    Task<School> Validate(ObjectId id);
}
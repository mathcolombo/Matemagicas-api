using Matemagicas.Domain.Classes.Entities;
using Matemagicas.Domain.Classes.Services.Commands;
using MongoDB.Bson;

namespace Matemagicas.Domain.Classes.Services.Interfaces;

public interface IClassesService
{
    Class Instantiate(ClassCreateCommand command);
    Task<Class> Validate(ObjectId id);
    Task<Class> UpdateAsync(ObjectId id, ClassUpdateCommand command);
    Task<Class> InactivateAsync(ObjectId id);
}
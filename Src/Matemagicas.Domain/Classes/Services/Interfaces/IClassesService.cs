using Matemagicas.Domain.Classes.Entities;
using Matemagicas.Domain.Classes.Services.Commands;
using MongoDB.Bson;

namespace Matemagicas.Domain.Classes.Services.Interfaces;

public interface IClassesService
{
    Task<Class> InstantiateAsync(ClassCreateCommand command);
    Task<Class> ValidateAsync(ObjectId id);
    Task<Class> UpdateAsync(ObjectId id, ClassUpdateCommand command);
    Task<Class> InactivateAsync(ObjectId id);
}
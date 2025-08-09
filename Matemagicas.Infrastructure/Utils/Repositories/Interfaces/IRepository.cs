using MongoDB.Bson;

namespace Matemagicas.Infrastructure.Utils.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    T Create(T entity);
    T? GetById(ObjectId id);
    T Update(T entity);
    void Delete(T entity);
    IQueryable<T> Query();
}
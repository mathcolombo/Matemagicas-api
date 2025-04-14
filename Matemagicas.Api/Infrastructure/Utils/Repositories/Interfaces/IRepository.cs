using MongoDB.Bson;

namespace Matemagicas.Api.Infrastructure.Utils.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    T Create(T entity);
    //IEnumerable<T> GetAll();
    T? GetById(ObjectId id);
    T Update(T entity);
    void Delete(T entity);
    IQueryable<T> Query();
}
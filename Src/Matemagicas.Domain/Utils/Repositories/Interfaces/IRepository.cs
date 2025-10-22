using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MongoDB.Bson;

namespace Matemagicas.Domain.Utils.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    T Create(T entity); //
    IEnumerable<T> Create(IEnumerable<T> entities); //
    T? GetById(ObjectId id); //
    T Update(T entity);
    IEnumerable<T> Update(IEnumerable<T> entities);
    void Delete(T entity);
    void Delete(IEnumerable<T> entities);
    IQueryable<T> Query();
    
    Task<T> CreateAsync(T entity);
    Task<IEnumerable<T>> CreateAsync(IEnumerable<T> entities);
    Task<T?> GetByIdAsync(ObjectId id);
    Task<int> UpdateAsync(Expression<Func<T, bool>> whereCondition, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls);
    Task<int> DeleteAsync(Expression<Func<T, bool>> whereCondition);
}
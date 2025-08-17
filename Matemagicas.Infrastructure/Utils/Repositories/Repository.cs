using System.Linq.Expressions;
using Matemagicas.Domain.Utils.Repositories.Interfaces;
using Matemagicas.Infrastructure.Configs.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MongoDB.Bson;

namespace Matemagicas.Infrastructure.Utils.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly MatemagicasDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(MatemagicasDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    
    #region Synchronous Methods
    
    public T Create(T entity) //
    {
        _dbSet.Add(entity);
        return entity;
    }

    public IEnumerable<T> Create(IEnumerable<T> entities) //
    {
        _dbSet.AddRange(entities);
        return entities;
    }
    
    public T? GetById(ObjectId id) => _dbSet.Find(id); //

    public T Update(T entity)
    {
        _dbSet.Update(entity);
        return entity;
    }
    
    public IEnumerable<T> Update(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
        return entities;
    } 

    public void Delete(T entity) => _dbSet.Remove(entity);
    public void Delete(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
    
    public IQueryable<T> Query() => _dbSet.AsNoTracking();
    
    #endregion
    
    #region Asynchronous Methods
    
    public async Task<T> CreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> CreateAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        return entities;
    }
    
    public async Task<T?> GetByIdAsync(ObjectId id) => await _dbSet.FindAsync(id);

    public async Task<int> UpdateAsync(Expression<Func<T, bool>> whereCondition, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls) =>
        await _dbSet.Where(whereCondition).ExecuteUpdateAsync(setPropertyCalls);

    public async Task<int> DeleteAsync(Expression<Func<T, bool>> whereCondition) =>
        await _dbSet.Where(whereCondition).ExecuteDeleteAsync();
    
    #endregion
}
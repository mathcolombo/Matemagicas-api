using Matemagicas.Api.Infrastructure.Context;
using Matemagicas.Api.Infrastructure.Utils.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace Matemagicas.Api.Infrastructure.Utils.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly MatemagicasDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(MatemagicasDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    
    public T Create(T entity)
    {
        _dbSet.Add(entity);
        return entity;
    }

    public T? GetById(ObjectId id) => _dbSet.Find(id);

    public T Update(T entity)
    {
        _dbSet.Update(entity);
        return entity;
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
    
    public IQueryable<T> Query() => _dbSet.AsQueryable();
}
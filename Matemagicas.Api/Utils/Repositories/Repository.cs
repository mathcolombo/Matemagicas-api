using Matemagicas.Api.Domain.Context;
using Matemagicas.Api.Utils.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Matemagicas.Api.Utils.Repositories;

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

    public T? GetById(int id) => _dbSet.Find(id);

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
namespace Matemagicas.Api.Utils.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    T Create(T entity);
    //IEnumerable<T> GetAll();
    T? GetById(int id);
    T Update(T entity);
    void Delete(T entity);
    IQueryable<T> Query();
}
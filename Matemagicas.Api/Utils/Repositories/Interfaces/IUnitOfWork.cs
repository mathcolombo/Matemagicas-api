namespace Matemagicas.Api.Utils.Repositories.Interfaces;

public interface IUnitOfWork
{
    void BeginTransaction();
    void Commit();
    void Rollback();
    void SaveChanges();
}
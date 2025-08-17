using Matemagicas.Domain.Users.Entities;
using Matemagicas.Domain.Users.Repositories.Filters;
using Matemagicas.Domain.Utils.Repositories.Interfaces;

namespace Matemagicas.Domain.Users.Repositories.Interfaces;

public interface IUsersRepository : IRepository<User>
{
    bool EmailExists(string email);
    IQueryable<User> Get(UserPagedFilter filter);
}
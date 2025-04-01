using Matemagicas.Api.Entities;
using Matemagicas.Api.Utils.Repositories.Interfaces;

namespace Matemagicas.Api.Repositories.Interfaces;

public interface IUsersRepository : IRepository<User>
{
    bool EmailExists(string email);
}
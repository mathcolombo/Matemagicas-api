using Matemagicas.Api.Domain.Entities;
using Matemagicas.Api.Infrastructure.Utils.Repositories.Interfaces;

namespace Matemagicas.Api.Infrastructure.Repositories.Interfaces;

public interface IUsersRepository : IRepository<User>
{
    bool EmailExists(string email);
}
using Domain.Entities;

namespace Infastructure.Repositories.Interfaces
{
    public interface IUserControlRepository
    {
        Task<List<User>> GetUsersAsync(CancellationToken cancellationToken);
        Task<User> GetUserAsync(int id, CancellationToken cancellationToken);
        Task<User> CreateUserAsync(User user, CancellationToken cancellationToken);
    }
}

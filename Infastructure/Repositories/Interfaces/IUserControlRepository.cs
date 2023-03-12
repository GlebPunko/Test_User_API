using Domain.Entities;

namespace Infastructure.Repositories.Interfaces
{
    public interface IUserControlRepository
    {
        Task<User> GetUserAsync(CancellationToken cancellationToken);
    }
}

using Domain.Entities;
using Infastructure.Repositories.Interfaces;

namespace Infastructure.Repositories
{
    public class UserControlRepository : IUserControlRepository
    {
        public async Task<User> GetUserAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        
    }
}

using Domain.Entities;
using Infastructure.Context;
using Infastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infastructure.Repositories
{
    public class UserControlRepository : IUserControlRepository
    {
        private readonly UserDbContext _context;

        public UserControlRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync(CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync(cancellationToken);
        }

        public async Task<User> GetUserAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<User> CreateUserAsync(User user, CancellationToken cancellationToken)
        {
            await _context.AddAsync(user, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}

using Application.Models;
using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IUserControlService
    {
        Task<Login> RegisterAsync(Register user, CancellationToken cancellationToken);
        Task<string> LoginAsync(Login login, CancellationToken cancellationToken);
        Task<Response> GetUserAsync(int id, CancellationToken cancellationToken);
    }
}

using Taskino.Domain.Models.Entities;

namespace Taskino.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(long id);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByUsernameAsync(string username);
        Task<bool> AddAsync(User user);
        Task<bool> UpdateAsync(User user);
    }
}

using Microsoft.EntityFrameworkCore;
using Taskino.Domain.Interfaces;
using Taskino.Domain.Models.Entities;
using Taskino.Infrastructure.Persistence.Data;

namespace Taskino.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User?> GetByIdAsync(long id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<User?> GetByUsernameAsync(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            return user;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            try
            {
                var model = await GetByIdAsync(user.Id);
                if (model == null)
                {
                    throw new Exception("User not found");
                }
                model.Name = user.Name;
                model.LastName = user.LastName;
                model.Password = user.Password;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

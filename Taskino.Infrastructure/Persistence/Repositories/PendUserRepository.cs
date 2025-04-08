using Microsoft.EntityFrameworkCore;
using Taskino.Domain.Interfaces;
using Taskino.Domain.Models.Entities;
using Taskino.Infrastructure.Persistence.Data;

namespace Taskino.Infrastructure.Persistence.Repositories
{
    public class PendUserRepository : IPendUserRegisterRepository
    {
        private readonly ApplicationDbContext _context;

        public PendUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(PendUserRegister pendUserRegister)
        {
            try
            {
                await _context.PendUserRegisters.AddAsync(pendUserRegister);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var pendUserRegister = await GetByIdAsync(id);
                if (pendUserRegister == null)
                {
                    throw new Exception("PendUserRegister not found");
                }
                return await DeleteAsync(pendUserRegister);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(PendUserRegister pendUserRegister)
        {
            try
            {
                _context.PendUserRegisters.Remove(pendUserRegister);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<PendUserRegister?> GetByIdAndCodeAsync(long id, string Code)
        {
            return await _context.PendUserRegisters.FirstOrDefaultAsync(p => p.Id == id && p.ConfirmationCode == Code);
        }

        public async Task<PendUserRegister?> GetByIdAsync(long id)
        {
            var pendUserRegister = await _context.PendUserRegisters.FirstOrDefaultAsync(p => p.Id == id);
            return pendUserRegister;
        }
    }
}

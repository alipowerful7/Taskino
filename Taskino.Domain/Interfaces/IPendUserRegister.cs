﻿using Taskino.Domain.Models.Entities;

namespace Taskino.Domain.Interfaces
{
    public interface IPendUserRegister
    {
        Task<PendUserRegister?> GetByIdAsync(long id);
        Task<bool> AddAsync(PendUserRegister pendUserRegister);
        Task<bool> DeleteAsync(long id);
        Task<bool> DeleteAsync(PendUserRegister pendUserRegister);
    }
}

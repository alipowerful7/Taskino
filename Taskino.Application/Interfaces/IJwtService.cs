using Taskino.Domain.Models.Entities;

namespace Taskino.Application.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}

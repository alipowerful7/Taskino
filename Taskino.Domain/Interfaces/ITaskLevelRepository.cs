using Taskino.Domain.Models.Enums;

namespace Taskino.Domain.Interfaces
{
    public interface ITaskLevelRepository
    {
        Task<IEnumerable<TaskLevel>> GetAllAsync();
    }
}

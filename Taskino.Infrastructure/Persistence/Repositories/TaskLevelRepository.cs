using Taskino.Domain.Interfaces;
using Taskino.Domain.Models.Enums;

namespace Taskino.Infrastructure.Persistence.Repositories
{
    public class TaskLevelRepository : ITaskLevelRepository
    {
        public async Task<IEnumerable<TaskLevel>> GetAllAsync()
        {
            return Enum.GetValues<TaskLevel>().ToList();
        }
    }
}

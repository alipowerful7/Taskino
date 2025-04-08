namespace Taskino.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Models.Entities.Task>> GetAllAsync(long userId);
        Task<Models.Entities.Task?> GetByIdAsync(long id);
        Task<bool> AddAsync(Models.Entities.Task task);
        Task<bool> UpdateAsync(Models.Entities.Task task);
        Task<bool> DeleteAsync(long id);
        Task<bool> DeleteAsync(Models.Entities.Task task);
    }
}

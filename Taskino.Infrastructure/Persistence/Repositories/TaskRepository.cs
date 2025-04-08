using Microsoft.EntityFrameworkCore;
using Taskino.Domain.Interfaces;
using Taskino.Infrastructure.Persistence.Data;

namespace Taskino.Infrastructure.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Domain.Models.Entities.Task task)
        {
            try
            {
                await _context.Tasks.AddAsync(task);
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
                var task = await GetByIdAsync(id);
                if (task == null)
                {
                    throw new Exception("Task not found");
                }
                var result = await DeleteAsync(task);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Domain.Models.Entities.Task task)
        {
            try
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Domain.Models.Entities.Task>> GetAllAsync(long userId)
        {
            var tasks = await _context.Tasks.Where(t => t.UserId == userId).ToListAsync();
            return tasks;
        }

        public Task<Domain.Models.Entities.Task?> GetByIdAsync(long id)
        {
            var task = _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            return task;
        }

        public async Task<IEnumerable<Domain.Models.Entities.Task>> GetTasksForReminder(DateTime reminderDate)
        {
            var tasks = await _context.Tasks.Include(t => t.User).Where(t => t.IsCompleted == false && t.DoneDate == reminderDate && t.IsReminderSent == false).ToListAsync();
            return tasks;
        }

        public async Task<bool> UpdateAsync(Domain.Models.Entities.Task task)
        {
            try
            {
                var model = await GetByIdAsync(task.Id);
                if (model == null)
                {
                    throw new Exception("Task not found");
                }
                model.Title = task.Title;
                model.Description = task.Description;
                model.DoneDate = task.DoneDate;
                model.IsCompleted = task.IsCompleted;
                model.TaskLevel = task.TaskLevel;
                model.IsReminderSent = false;
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

using MediatR;
using Taskino.Domain.Interfaces;

namespace Taskino.Application.Commands.Task.Update
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, bool>
    {
        private readonly ITaskRepository _taskRepository;

        public UpdateTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var task = await _taskRepository.GetByIdAsync(request.UpdateTaskDto.Id);
                if (task == null)
                {
                    throw new Exception("Task not found");
                }
                if (task.DoneDate < DateTime.UtcNow || request.UpdateTaskDto.DoneDate < DateTime.UtcNow)
                {
                    throw new Exception("You can not edit done time");
                }
                task.Title = request.UpdateTaskDto.Title;
                task.Description = request.UpdateTaskDto.Description;
                task.DoneDate = request.UpdateTaskDto.DoneDate;
                task.IsCompleted = request.UpdateTaskDto.IsCompleted;
                task.TaskLevel = request.UpdateTaskDto.TaskLevel;
                var result = await _taskRepository.UpdateAsync(task);
                if (result)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Task not updated");
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

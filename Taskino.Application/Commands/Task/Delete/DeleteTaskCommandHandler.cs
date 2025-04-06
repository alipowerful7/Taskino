using MediatR;
using Taskino.Domain.Interfaces;

namespace Taskino.Application.Commands.Task.Delete
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var task = await _taskRepository.GetByIdAsync(request.DeleteTaskDto.Id);
                if (task == null)
                {
                    throw new Exception("Task not found");
                }
                var result = await _taskRepository.DeleteAsync(task);
                if (result)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Task could not be delete");
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

using MediatR;
using Taskino.Domain.Interfaces;

namespace Taskino.Application.Commands.Task.Create
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, bool>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        public CreateTaskCommandHandler(ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.CreateTaskDto.UserId);
                if (user == null)
                {
                    throw new UnauthorizedAccessException("User not found");
                }
                var task = new Domain.Models.Entities.Task
                {
                    Title = request.CreateTaskDto.Title,
                    Description = request.CreateTaskDto.Description,
                    UserId = request.CreateTaskDto.UserId,
                    DoneDate = request.CreateTaskDto.DoneDate,
                    IsCompleted = false,
                    IsReminderSent = false,
                    TaskLevel = request.CreateTaskDto.TaskLevel,
                    CreateDate = DateTime.UtcNow,
                };
                var result = await _taskRepository.AddAsync(task);
                if (result)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Task could not be created");
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

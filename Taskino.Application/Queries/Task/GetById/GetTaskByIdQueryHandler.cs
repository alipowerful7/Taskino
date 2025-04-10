using MediatR;
using Taskino.Application.Dtos.Task;
using Taskino.Domain.Interfaces;

namespace Taskino.Application.Queries.Task.GetById
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, ReadTaskDto>
    {
        private readonly ITaskRepository _taskRepository;

        public GetTaskByIdQueryHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<ReadTaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetByIdAsync(request.ReadTaskDto.Id);
            if (task == null)
            {
                throw new Exception($"Task with Id {request.ReadTaskDto.Id} not found.");
            }
            var result = new ReadTaskDto()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CreateDate = task.CreateDate,
                TaskLevel = task.TaskLevel.ToString(),
                DoneDate = task.DoneDate,
                IsCompleted = task.IsCompleted
            };
            return result;
        }
    }
}

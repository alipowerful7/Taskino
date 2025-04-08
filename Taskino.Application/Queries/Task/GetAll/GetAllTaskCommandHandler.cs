using MediatR;
using Taskino.Application.Dtos.Task;
using Taskino.Domain.Interfaces;

namespace Taskino.Application.Queries.Task.GetAll
{
    public class GetAllTaskCommandHandler : IRequestHandler<GetAllTaskCommand, IEnumerable<ReadTaskDto>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetAllTaskCommandHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<ReadTaskDto>> Handle(GetAllTaskCommand request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAllAsync(request.ReadTaskDto.UserId);
            var result = new List<ReadTaskDto>();
            foreach (var task in tasks)
            {
                result.Add(new ReadTaskDto
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    CreateDate = task.CreateDate,
                    DoneDate = task.DoneDate,
                    IsCompleted = task.IsCompleted,
                    TaskLevel = task.TaskLevel
                });
            }
            return result;
        }
    }
}

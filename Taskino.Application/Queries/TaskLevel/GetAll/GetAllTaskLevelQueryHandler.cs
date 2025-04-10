using MediatR;
using Taskino.Application.Dtos.TaskLevel;
using Taskino.Domain.Interfaces;

namespace Taskino.Application.Queries.TaskLevel.GetAll
{
    public class GetAllTaskLevelQueryHandler : IRequestHandler<GetAllTaskLevelQuery, IEnumerable<ReadTaskLevelDto>>
    {
        private readonly ITaskLevelRepository _taskLevelRepository;

        public GetAllTaskLevelQueryHandler(ITaskLevelRepository taskLevelRepository)
        {
            _taskLevelRepository = taskLevelRepository;
        }

        public async Task<IEnumerable<ReadTaskLevelDto>> Handle(GetAllTaskLevelQuery request, CancellationToken cancellationToken)
        {
            var taskLevels = await _taskLevelRepository.GetAllAsync();
            return taskLevels.Select(taskLevel => new ReadTaskLevelDto()
            {
                Id = (long)taskLevel,
                Name = taskLevel.ToString()
            }).ToList();
        }
    }
}

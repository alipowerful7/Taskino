using MediatR;
using Taskino.Application.Dtos.TaskLevel;

namespace Taskino.Application.Queries.TaskLevel.GetAll
{
    public class GetAllTaskLevelQuery : IRequest<IEnumerable<ReadTaskLevelDto>>
    {
        public ReadTaskLevelDto ReadTaskLevelDto { get; set; }

        public GetAllTaskLevelQuery(ReadTaskLevelDto readTaskLevelDto)
        {
            ReadTaskLevelDto = readTaskLevelDto;
        }
    }
}

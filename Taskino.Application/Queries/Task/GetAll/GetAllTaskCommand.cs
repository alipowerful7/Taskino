using MediatR;
using Taskino.Application.Dtos.Task;

namespace Taskino.Application.Queries.Task.GetAll
{
    public class GetAllTaskCommand : IRequest<IEnumerable<ReadTaskDto>>
    {
        public ReadTaskDto ReadTaskDto { get; set; }

        public GetAllTaskCommand(ReadTaskDto readTaskDto)
        {
            ReadTaskDto = readTaskDto;
        }
    }
}

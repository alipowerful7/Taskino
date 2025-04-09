using MediatR;
using Taskino.Application.Dtos.Task;

namespace Taskino.Application.Queries.Task.GetAll
{
    public class GetAllTaskQuery : IRequest<IEnumerable<ReadTaskDto>>
    {
        public ReadTaskDto ReadTaskDto { get; set; }

        public GetAllTaskQuery(ReadTaskDto readTaskDto)
        {
            ReadTaskDto = readTaskDto;
        }
    }
}

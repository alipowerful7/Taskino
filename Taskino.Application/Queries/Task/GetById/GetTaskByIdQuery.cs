using MediatR;
using Taskino.Application.Dtos.Task;

namespace Taskino.Application.Queries.Task.GetById
{
    public class GetTaskByIdQuery : IRequest<ReadTaskDto>
    {
        public ReadTaskDto ReadTaskDto { get; set; }

        public GetTaskByIdQuery(ReadTaskDto readTaskDto)
        {
            ReadTaskDto = readTaskDto;
        }
    }
}

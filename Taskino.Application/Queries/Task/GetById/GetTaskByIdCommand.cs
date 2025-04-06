using MediatR;
using Taskino.Application.Dtos.Task;

namespace Taskino.Application.Queries.Task.GetById
{
    public class GetTaskByIdCommand : IRequest<ReadTaskDto>
    {
        public ReadTaskDto ReadTaskDto { get; set; }

        public GetTaskByIdCommand(ReadTaskDto readTaskDto)
        {
            ReadTaskDto = readTaskDto;
        }
    }
}

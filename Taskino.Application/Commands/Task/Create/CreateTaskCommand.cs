using MediatR;
using Taskino.Application.Dtos.Task;

namespace Taskino.Application.Commands.Task.Create
{
    public class CreateTaskCommand : IRequest<bool>
    {
        public CreateTaskDto CreateTaskDto { get; set; }

        public CreateTaskCommand(CreateTaskDto createTaskDto)
        {
            CreateTaskDto = createTaskDto;
        }
    }
}

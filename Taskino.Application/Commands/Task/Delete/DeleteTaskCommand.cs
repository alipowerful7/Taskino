using MediatR;
using Taskino.Application.Dtos.Task;

namespace Taskino.Application.Commands.Task.Delete
{
    public class DeleteTaskCommand : IRequest<bool>
    {
        public DeleteTaskDto DeleteTaskDto { get; set; }

        public DeleteTaskCommand(DeleteTaskDto deleteTaskDto)
        {
            DeleteTaskDto = deleteTaskDto;
        }
    }
}

using MediatR;
using Taskino.Application.Dtos.Task;

namespace Taskino.Application.Commands.Task.Update
{
    public class UpdateTaskCommand : IRequest<bool>
    {
        public UpdateTaskDto UpdateTaskDto { get; set; }

        public UpdateTaskCommand(UpdateTaskDto updateTaskDto)
        {
            UpdateTaskDto = updateTaskDto;
        }
    }
}

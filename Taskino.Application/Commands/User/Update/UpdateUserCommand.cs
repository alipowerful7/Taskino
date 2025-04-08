using MediatR;
using Taskino.Application.Dtos.User;

namespace Taskino.Application.Commands.User.Update
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public UpdateUserDto UpdateUserDto { get; set; }

        public UpdateUserCommand(UpdateUserDto updateUserDto)
        {
            UpdateUserDto = updateUserDto;
        }
    }
}

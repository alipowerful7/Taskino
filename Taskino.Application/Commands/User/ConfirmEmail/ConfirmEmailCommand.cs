using MediatR;
using Taskino.Application.Dtos.User;

namespace Taskino.Application.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<bool>
    {
        public ConfirmUserEmailDto ConfirmUserEmailDto { get; set; }

        public ConfirmEmailCommand(ConfirmUserEmailDto confirmUserEmailDto)
        {
            ConfirmUserEmailDto = confirmUserEmailDto;
        }
    }
}

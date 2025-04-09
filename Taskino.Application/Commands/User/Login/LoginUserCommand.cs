using MediatR;
using Taskino.Application.Dtos.User;

namespace Taskino.Application.Commands.User.Login
{
    public class LoginUserCommand : IRequest<string?>
    {
        public LoginUserDto LoginUserDto { get; set; }

        public LoginUserCommand(LoginUserDto loginUserDto)
        {
            LoginUserDto = loginUserDto;
        }
    }
}

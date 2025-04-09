using MediatR;
using Taskino.Application.Interfaces;
using Taskino.Domain.Interfaces;

namespace Taskino.Application.Commands.User.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string?>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public LoginUserCommandHandler(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<string?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByUsernameAsync(request.LoginUserDto.UserName!);
                if (user == null)
                    throw new Exception("Invalid username or password");

                if (!BCrypt.Net.BCrypt.Verify(request.LoginUserDto.Password, user.Password))
                    throw new Exception("Invalid username or password");

                return _jwtService.GenerateToken(user);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

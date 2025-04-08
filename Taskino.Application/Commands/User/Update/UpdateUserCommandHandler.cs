using MediatR;
using Taskino.Domain.Interfaces;

namespace Taskino.Application.Commands.User.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.UpdateUserDto.Id);
                if (user == null)
                {
                    throw new Exception($"User with Id {request.UpdateUserDto.Id} not found.");
                }
                if (await _userRepository.GetByUsernameAsync(request.UpdateUserDto.UserName!) != null)
                {
                    throw new Exception($"User with username {request.UpdateUserDto.UserName} already exists.");
                }
                if (await _userRepository.CheckOldPassword(request.UpdateUserDto.Id, request.UpdateUserDto.OldPassword!) == false)
                {
                    throw new Exception("Old password is incorrect.");
                }
                user.FirstName = request.UpdateUserDto.FirstName;
                user.LastName = request.UpdateUserDto.LastName;
                user.UserName = request.UpdateUserDto.UserName;
                user.Password = BCrypt.Net.BCrypt.HashPassword(request.UpdateUserDto.NewPassword);
                await _userRepository.UpdateAsync(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

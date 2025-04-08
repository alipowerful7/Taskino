using MediatR;
using Taskino.Domain.Interfaces;
using Taskino.Domain.Models.Enums;

namespace Taskino.Application.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IPendUserRegisterRepository _pendUserRegisterRepository;
        private readonly IUserRepository _userRepository;

        public ConfirmEmailCommandHandler(IPendUserRegisterRepository pendUserRegisterRepository, IUserRepository userRepository)
        {
            _pendUserRegisterRepository = pendUserRegisterRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var pendUserRegister = _pendUserRegisterRepository.GetByIdAndCodeAsync(request.ConfirmUserEmailDto.Id, request.ConfirmUserEmailDto.Code!);
                if (pendUserRegister == null || pendUserRegister.Result?.CodeExpiresAt < DateTime.UtcNow)
                {
                    throw new Exception("Invalid or expired code");
                }
                var user = new Domain.Models.Entities.User()
                {
                    Email = pendUserRegister.Result?.Email,
                    CreateDate = DateTime.UtcNow,
                    Name = pendUserRegister.Result?.Name,
                    LastName = pendUserRegister.Result?.LastName,
                    Password = pendUserRegister.Result?.Password,
                    UserName = pendUserRegister.Result?.UserName,
                    UserRole = UserRole.NormalUser
                };
                await _userRepository.AddAsync(user);
                await _pendUserRegisterRepository.DeleteAsync(pendUserRegister.Result!);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

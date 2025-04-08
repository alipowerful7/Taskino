using MediatR;
using Taskino.Application.Interfaces;
using Taskino.Domain.Interfaces;

namespace Taskino.Application.Commands.PendUserRegister.Create
{
    public class CreatePendUserRegisterCommandHandler : IRequestHandler<CreatePendUserRegisterCommand, long>
    {
        private readonly IPendUserRegisterRepository _pendUserRegisterRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public CreatePendUserRegisterCommandHandler(IPendUserRegisterRepository pendUserRegisterRepository, IUserRepository userRepository, IEmailService emailService)
        {
            _pendUserRegisterRepository = pendUserRegisterRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<long> Handle(CreatePendUserRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (await _userRepository.GetByUsernameAsync(request.CreatePendUserRegisterDto.UserName!) != null)
                {
                    throw new Exception("Username already exists");
                }
                if (await _userRepository.GetByEmailAsync(request.CreatePendUserRegisterDto.Email!) != null)
                {
                    throw new Exception("Email already exists");
                }
                var confirmationCode = new Random().Next(100000, 999999).ToString();
                var expiration = DateTime.UtcNow.AddMinutes(15);
                var pendUserRegister = new Domain.Models.Entities.PendUserRegister()
                {
                    Name = request.CreatePendUserRegisterDto.Name,
                    LastName = request.CreatePendUserRegisterDto.LastName,
                    UserName = request.CreatePendUserRegisterDto.UserName,
                    Password = request.CreatePendUserRegisterDto.Password,
                    Email = request.CreatePendUserRegisterDto.Email,
                    ConfirmationCode = confirmationCode,
                    CodeExpiresAt = expiration,
                    CreateDate = DateTime.UtcNow
                };
                if (await _pendUserRegisterRepository.AddAsync(pendUserRegister))
                {
                    var emailSent = await _emailService.SendConfirmationEmailAsync(request.CreatePendUserRegisterDto.Email!, confirmationCode);
                    if (emailSent)
                    {
                        return pendUserRegister.Id;
                    }
                    else
                    {
                        throw new Exception("Failed to send confirmation email");
                    }
                }
                else
                {
                    throw new Exception("Failed to create pending user register");
                }
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while creating the pending user register");
            }
        }
    }
}

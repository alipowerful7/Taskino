using MediatR;
using Taskino.Domain.Interfaces;

namespace Taskino.Application.Commands.PendUserRegister.Delete
{
    public class DeletePendUserRegisterCommandHandler : IRequestHandler<DeletePendUserRegisterCommand, bool>
    {
        private readonly IPendUserRegisterRepository _pendUserRegisterRepository;

        public DeletePendUserRegisterCommandHandler(IPendUserRegisterRepository pendUserRegisterRepository)
        {
            _pendUserRegisterRepository = pendUserRegisterRepository;
        }

        public async Task<bool> Handle(DeletePendUserRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _pendUserRegisterRepository.DeleteAsync(request.DeletePendUserRegisterDto.Id);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

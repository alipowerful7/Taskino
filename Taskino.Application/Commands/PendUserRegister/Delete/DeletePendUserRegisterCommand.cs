using MediatR;
using Taskino.Application.Dtos.PendUserRegister;

namespace Taskino.Application.Commands.PendUserRegister.Delete
{
    public class DeletePendUserRegisterCommand : IRequest<bool>
    {
        public DeletePendUserRegisterDto DeletePendUserRegisterDto { get; set; }

        public DeletePendUserRegisterCommand(DeletePendUserRegisterDto deletePendUserRegisterDto)
        {
            DeletePendUserRegisterDto = deletePendUserRegisterDto;
        }
    }
}

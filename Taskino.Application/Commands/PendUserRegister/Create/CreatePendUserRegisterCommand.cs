using MediatR;
using Taskino.Application.Dtos.PendUserRegister;

namespace Taskino.Application.Commands.PendUserRegister.Create
{
    public class CreatePendUserRegisterCommand : IRequest<long>
    {
        public CreatePendUserRegisterDto CreatePendUserRegisterDto { get; set; }

        public CreatePendUserRegisterCommand(CreatePendUserRegisterDto createPendUserRegisterDto)
        {
            CreatePendUserRegisterDto = createPendUserRegisterDto;
        }
    }
}

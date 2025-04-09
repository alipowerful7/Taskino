using MediatR;
using Microsoft.AspNetCore.Mvc;
using Taskino.Application.Commands.PendUserRegister.Create;
using Taskino.Application.Commands.User.ConfirmEmail;
using Taskino.Application.Commands.User.Login;

namespace Taskino.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreatePendUserRegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new { Id = result });
        }
        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
        {
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Code id wrong");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserCommand command)
        {
            var user = await _mediator.Send(command);
            if (user != null)
            {
                return Ok(new { Token = user });
            }
            return BadRequest("Username or password is wrong");
        }
    }
}

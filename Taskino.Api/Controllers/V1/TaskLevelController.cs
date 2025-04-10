using MediatR;
using Microsoft.AspNetCore.Mvc;
using Taskino.Application.Queries.TaskLevel.GetAll;

namespace Taskino.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public class TaskLevelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskLevelController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTaskLevelQuery(new Application.Dtos.TaskLevel.ReadTaskLevelDto()));
            return Ok(result);
        }
    }
}

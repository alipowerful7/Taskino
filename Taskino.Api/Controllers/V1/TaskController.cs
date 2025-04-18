﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskino.Application.Commands.Task.Create;
using Taskino.Application.Commands.Task.Delete;
using Taskino.Application.Commands.Task.Update;
using Taskino.Application.Dtos.Task;
using Taskino.Application.Queries.Task.GetAll;
using Taskino.Application.Queries.Task.GetById;

namespace Taskino.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskCommand command)
        {
            var userId = long.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            command.CreateTaskDto.UserId = userId;
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest("Task could not be created");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, UpdateTaskCommand command)
        {
            command.UpdateTaskDto.Id = id;
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Task could not be updated");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var command = new DeleteTaskCommand(new DeleteTaskDto { Id = id });
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Task could not be deleted");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = long.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            var tasks = await _mediator.Send(new GetAllTaskQuery(new ReadTaskDto { UserId = userId }));
            if (tasks != null)
            {
                return Ok(tasks);
            }
            return NotFound("No tasks found");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var userId = long.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            var task = await _mediator.Send(new GetTaskByIdQuery(new ReadTaskDto { Id = id }));
            if (task != null)
            {
                return Ok(task);
            }
            return NotFound("Task not found");
        }
    }
}

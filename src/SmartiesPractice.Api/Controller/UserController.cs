using Mediator.Net;
using Microsoft.AspNetCore.Mvc;
using SmartiesPractice.Messages.Users;

namespace SmartiesPractice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateUserResponse>> Create(
        [FromBody] CreateUserCommand command,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.SendAsync<CreateUserCommand, CreateUserResponse>(
            command, cancellationToken);

        var user = response.User;
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, response);
    }

    [HttpGet]
    public async Task<ActionResult<GetUsersResponse>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.RequestAsync<GetUsersRequest, GetUsersResponse>(
            new GetUsersRequest(), cancellationToken);

        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetUserByIdResponse>> GetById(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.RequestAsync<GetUserByIdRequest, GetUserByIdResponse>(
            new GetUserByIdRequest(id), cancellationToken);

        if (response.User is null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpPost("{id:int}")]
    public async Task<ActionResult<UpdateUserResponse>> Update(
        int id,
        [FromBody] UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.SendAsync<UpdateUserCommand, UpdateUserResponse>(
            new UpdateUserCommand(id, request), cancellationToken);

        if (response.User is null)
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<DeleteUserResponse>> Delete(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.SendAsync<DeleteUserCommand, DeleteUserResponse>(
            new DeleteUserCommand(id), cancellationToken);

        if (!response.Deleted)
        {
            return NotFound();
        }

        return Ok(response);
    }
}

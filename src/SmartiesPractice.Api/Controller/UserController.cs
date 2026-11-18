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
    public async Task<ActionResult<User>> Create(
        [FromBody] CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.RequestAsync<CreateUserRequest, CreateUserResponse>(
            request, cancellationToken);

        var user = response.User;
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.RequestAsync<GetUsersRequest, GetUsersResponse>(
            new GetUsersRequest(), cancellationToken);

        return Ok(response.Users);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetById(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.RequestAsync<GetUserByIdRequest, GetUserByIdResponse>(
            new GetUserByIdRequest(id), cancellationToken);

        if (response.User is null)
        {
            return NotFound();
        }

        return Ok(response.User);
    }

    [HttpPost("{id:int}")]
    public async Task<ActionResult<User>> Update(
        int id,
        [FromBody] UpdateUserRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.RequestAsync<UpdateUserMessage, UpdateUserResponse>(
            new UpdateUserMessage(id, request), cancellationToken);

        if (response.User is null)
        {
            return NotFound();
        }

        return Ok(response.User);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var response = await _mediator.RequestAsync<DeleteUserRequest, DeleteUserResponse>(
            new DeleteUserRequest(id), cancellationToken);

        if (!response.Deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}

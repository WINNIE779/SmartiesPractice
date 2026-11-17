using Microsoft.AspNetCore.Mvc;
using SmartiesPractice.Core.Users;
using SmartiesPractice.Messages.Users;

namespace SmartiesPractice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public ActionResult<User> Create([FromBody] CreateUserRequest request)
    {
        var user = _userService.Create(request);

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpGet]
    public ActionResult<List<User>> GetAll()
    {
        return Ok(_userService.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<User> GetById(int id)
    {
        var user = _userService.GetById(id);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost("{id:int}")]
    public ActionResult<User> Update(
        int id,
        [FromBody] UpdateUserRequest request)
    {
        var user = _userService.Update(id, request);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var deleted = _userService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}
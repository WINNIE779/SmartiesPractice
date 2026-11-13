using Microsoft.AspNetCore.Mvc;
using SmartiesPractice.Messages.Users;

namespace SmartiesPractice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private static readonly List<User> Users = new();

    private static int _nextId = 1;
    
    [HttpPost]
    public ActionResult<User> Create([FromBody] CreateUserRequest request)
    {
        var user = new User
        {
            Id = _nextId++,
            Name = request.Name,
            Age = request.Age
        };

        Users.Add(user);

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }
   
    //单个id用户查询
    [HttpGet("{id:int}")]
    public ActionResult<User> GetById(int id)
    {
        var user = Users.FirstOrDefault(user => user.Id == id);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }
    
    // update可以用post也可以用put
    [HttpPost("{id:int}")]
    public ActionResult<User> Update(
        int id,
        [FromBody] UpdateUserRequest request)
    {
        var user = Users.FirstOrDefault(item => item.Id == id);

        if (user is null)
        {
            return NotFound();
        }

        user.Name = request.Name;
        user.Age = request.Age;

        return Ok(user);
    }

    //Delete:找到对应的item的id，判断是否存在，如果不存在返回空，如果有移除掉该user，返回ok；
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var user = Users.FirstOrDefault(item=>item.Id == id);

        if (user is null)
        {
            return NotFound();
        }
        
        Users.Remove(user);
        return Ok();
    }
    
    //Read：全部查询
    [HttpGet]
    public ActionResult<List<User>> GetAll()
    {
        return Ok(Users);
    }
    
    
}


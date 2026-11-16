using Microsoft.AspNetCore.Mvc;

namespace SmartiesPractice.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Hello World!";
    }
}
using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;

[Route("myfirstapi/[controller]")]
[ApiController]
public abstract class MyFirstApiBaseController : ControllerBase
{
    [HttpGet("healthy")]
    public IActionResult Healthy()
    {
        return Ok("It's working");
    }

    protected string GetCustomKey()
    {
        return Request.Headers["Mykey"].ToString();
    }
}

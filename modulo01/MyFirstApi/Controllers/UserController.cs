using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Communication.Request;
using MyFirstApi.Communication.Requests;
using MyFirstApi.Communication.Responses;

namespace MyFirstApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("get-user")]
    [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult Get([FromHeader] int id, [FromHeader] string? name) // enviar pelo header, o ? é opcional
    {
        User res = new User()
        {
            Id = 1,
            Name = "Romario",
            Age = 20
        };
        return Ok(res);
    }

    [HttpGet("get-all-user")]
    [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        var response = new List<User>()
        {
            new User { Id = 1, Name = "Teste1", Age = 20 }, 
            new User { Id = 2, Name = "Teste2", Age = 22 }, 
            new User { Id = 3, Name = "Teste3", Age = 28 }, 
        };

        return Ok(response);
    }

    [HttpPut("change-password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult ChangePassword([FromBody] RequestChangePasswordJson request)
    {
        return NoContent();
    }

    [HttpPost("create-user")]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] RequestRegisterUserJson request)
    {
        var response = new ResponseRegisteredUserJson()
        {
            Id = 1,
            Name = "teste"
        };

        return Created(string.Empty, response);
    }

    [HttpPut("update-user")]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestUpdateUserJson request)
    {
        return NoContent();
    }

    [HttpDelete("delete-user")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete()
    {
        return NoContent();
    }
}

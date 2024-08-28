using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(Retorno), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult Get()
    {
        Retorno res = new Retorno()
        {
            Id = 1,
            Nome = "Romario"
        };
        return Ok(res);
    }

    public class Retorno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}

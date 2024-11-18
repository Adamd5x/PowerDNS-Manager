using Microsoft.AspNetCore.Mvc;

namespace hiPower.WebApi.Controllers
{
    [Route ("api/config")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ConfigController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetConfig()
        {
            return Ok ();
        }
    }
}

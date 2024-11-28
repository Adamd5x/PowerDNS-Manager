using Microsoft.AspNetCore.Mvc;

namespace hiPower.WebApi.Controllers
{
    [Route ("api/servers")]
    [ApiController]
    [Produces (MediaTypeNames.Application.Json)]
    public class ServersController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<IEnumerable<Server>>))]
        public IActionResult GetAll ()
        {
            var response = new ApiResult<IEnumerable<Server>>(true, []);

            return Ok (response);
        }


        [HttpGet ("{id}")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<Server>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType (StatusCodes.Status404NotFound, Type = typeof (ProblemDetails))]
        public IActionResult Get ([FromRoute] string id)
        {
            var result = new ApiResult<Server>(true, new Server());
            return Ok (result);
        }

        [HttpGet ("{id}/zones")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<IEnumerable<Zone>>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType (StatusCodes.Status404NotFound, Type = typeof (ProblemDetails))]
        public IActionResult GetZones ([FromRoute] string id)
        {
            IEnumerable<Zone> zones = [
                new Zone("example-1.eu",ZoneKind.Slave, ["127.0.0.1"], false, 2024051626),
                new Zone("example-2.eu",ZoneKind.Slave, ["127.0.0.1"], false, 2024100116),
                new Zone("example-3.pl",ZoneKind.Slave, ["127.0.0.1"], false, 2021090103),
            ];

            var result = new ApiResult<IEnumerable<Zone>>(true, zones);
            return Ok (result);
        }
    }
}

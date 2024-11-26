using Microsoft.AspNetCore.Mvc;

namespace hiPower.WebApi.Controllers
{
    [Route ("api/servers")]
    [ApiController]
    [Produces (MediaTypeNames.Application.Json)]
    public class ServersController : ControllerBase
    {

        private readonly Server testServer = new Server("c97506f5-abc1-11ef-b546-7ae5db898729", "c83ba0fe-abbe-11ef-bee0-edb790a320a9", "Master 001", CommunicationProto.HTTP, "dnsserver", 18081, "abd79ec4-abc2-11ef-84de-64cd2e0dafcf", "b3c9bf7b-abc2-11ef-bbff-a71551192595");

        [HttpGet]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<IEnumerable<Server>>))]
        public IActionResult GetAll ()
        {
            var response = new ApiResult<IEnumerable<Server>>(true, [testServer]);

            return Ok (response);
        }


        [HttpGet ("{id}")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<Server>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType (StatusCodes.Status404NotFound, Type = typeof (ProblemDetails))]
        public IActionResult Get ([FromRoute] string id)
        {
            var result = new ApiResult<Server>(true, testServer);
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

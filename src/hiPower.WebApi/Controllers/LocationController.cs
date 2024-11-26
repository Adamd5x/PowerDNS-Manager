using Microsoft.AspNetCore.Mvc;

namespace hiPower.WebApi.Controllers
{
    [Route ("api/locations")]
    [ApiController]
    [Produces (MediaTypeNames.Application.Json)]
    public class LocationController : ControllerBase
    {

        private readonly Location testLocation = new Location("c83ba0fe-abbe-11ef-bee0-edb790a320a9", "Hq","Address","City","ZIP","Region","Poland","Virtual location for testing");

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type= typeof (ApiResult<IEnumerable<Location>>))]
        public IActionResult GetAll()
        {
            var newLocation = testLocation with { Name = "Home"};

            var response = new ApiResult<IEnumerable<Location>>(true, [newLocation]);

            return Ok (response);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(ApiResult<Location>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public IActionResult Get ([FromRoute] string id)
        {
            var result = new ApiResult<Location>(true, testLocation);
            return Ok (result);
        }

        [HttpGet ("{id}/servers")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<IEnumerable<Server>>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType (StatusCodes.Status404NotFound, Type = typeof (ProblemDetails))]
        public IActionResult GetServers ([FromRoute] string id)
        {
            IEnumerable<Server> serverList = [
                new Server("c97506f5-abc1-11ef-b546-7ae5db898729", "c83ba0fe-abbe-11ef-bee0-edb790a320a9", "Master 001", CommunicationProto.HTTP, "dnsserver", 53, "abd79ec4-abc2-11ef-84de-64cd2e0dafcf", "b3c9bf7b-abc2-11ef-bbff-a71551192595")
            ];

            var result = new ApiResult<IEnumerable<Server>>(true, serverList);
            return Ok (result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResult<Location>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        public IActionResult Create ([FromBody] Location location)
        {
            var result = new ApiResult<Location>(true, testLocation);

            return Created(string.Empty, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult<bool>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        public IActionResult Update ([FromRoute] string id, [FromBody] Location location)
        {

            var result = new ApiResult<bool>(true, true);

            return Ok (result);
        }

        [HttpDelete ("id")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<bool>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType (StatusCodes.Status404NotFound, Type = typeof (ProblemDetails))]
        public IActionResult Delete ([FromRoute] string id) 
        {
            var result = new ApiResult<bool>(true, true);
            return Ok (result);
        }
    }
}

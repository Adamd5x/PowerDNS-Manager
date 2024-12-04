using ErrorOr;
using hiPower.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace hiPower.WebApi.Controllers
{
    [Route ("api/servers")]
    [ApiController]
    [Produces (MediaTypeNames.Application.Json)]
    public class ServersController(IServerService serverService) : ControllerBase
    {
        [HttpGet("{dataCenterId}")]
        [ValidateIdFilter]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<IEnumerable<Server>>))]
        public async Task<IActionResult> GetAll ([FromRoute] string dataCenterId)
        {
            var result = await serverService.GetAllAsync (dataCenterId);
            bool notFound = result.IsError && result.FirstError.Type == ErrorType.NotFound;

            if (notFound)
            {
                return NotFound ();
            }

            return Ok (new ApiResult<IEnumerable<Server>>(!result.IsError, result.Value));
        }


        [HttpGet ("{id}/server")]
        [ValidateIdFilter]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<Server>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType (StatusCodes.Status404NotFound, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Get ([FromRoute] string id)
        {
            var result = await serverService.GetAsync (id);

            bool notFound = result.IsError && result.FirstError.Type == ErrorType.NotFound;

            if (notFound)
            {
                return NotFound ();
            }

            return Ok (new ApiResult<Server> (!result.IsError, result.Value));
        }

        [HttpGet("datacenters")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<IEnumerable<HintItem>>))]
        public async Task<IActionResult> HintDataCenters()
        {
            var result = await serverService.GetAvailableDataCentersAsync ();
            bool notFound = result.IsError && result.FirstError.Type == ErrorType.NotFound;
            if (notFound)
            {
                return NotFound();
            }
            return Ok (new ApiResult<IEnumerable<HintItem>>(true, result.Value));
        }

        [HttpPost]
        [VallidatModel]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResult<Server>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Create ([FromBody] Server server)
        {
            var result = await serverService.CreateAsync(server);
            return Created (string.Empty, new ApiResult<Server> (!result.IsError, result.Value));
        }

        [HttpPut ("{id}")]
        [ValidateIdFilter]
        [VallidatModel]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<Server>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Update ([FromRoute] string id, [FromBody] Server server)
        {
            var result = await serverService.UpdateAsync(id, server);
            bool notFound = result.IsError && result.FirstError.Type == ErrorType.NotFound;
            if (notFound)
            {
                return NotFound ();
            }
            return Ok (new ApiResult<Server> (!result.IsError, result.Value));
        }

        [HttpDelete("{id}")]
        [ValidateIdFilter]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<Server>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Deleted ([FromQuery] string id)
        {
            var result = await serverService.DeleteAsync(id);
            bool notFound = result.IsError && result.FirstError.Type == ErrorType.NotFound;
            if (notFound)
            {
                return NotFound ();
            }
            return Ok ();
        }
    }
}

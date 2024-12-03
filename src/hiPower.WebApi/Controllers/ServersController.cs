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
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<IEnumerable<Server>>))]
        public async Task<IActionResult> GetAll ([FromRoute] string dataCenterId)
        {
            var response = await serverService.GetAllAsync (dataCenterId);

            if (response.IsError)
            {
                return BadRequest ();
            }

            return Ok (new ApiResult<IEnumerable<Server>>(!response.IsError, response.Value));
        }


        [HttpGet ("{id}/server")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<Server>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType (StatusCodes.Status404NotFound, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Get ([FromRoute] string id)
        {
            var result = await serverService.GetAsync (id);

            if (result.IsError)
            {
                return NotFound ();
            }

            return Ok (new ApiResult<Server>(!result.IsError, result.Value));
        }

        [HttpGet("datacenters")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<IEnumerable<HintItem>>))]
        public async Task<IActionResult> HintDataCenters()
        {
            var result = await serverService.GetAvailableDataCentersAsync ();
            if (result.IsError)
            {
                return BadRequest ();
            }
            return Ok (new ApiResult<IEnumerable<HintItem>>(true, result.Value));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResult<Server>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Create ([FromBody] Server server)
        {
            var result = await serverService.CreateAsync(server);
            if (result.IsError)
            {
                return BadRequest ();
            }
            return Created (string.Empty, new ApiResult<Server> (!result.IsError, result.Value));
        }

        [HttpPut ("{id}")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<Server>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Update ([FromRoute] string id, [FromBody] Server server)
        {
            var result = await serverService.UpdateAsync(id, server);
            if (result.IsError)
            {
                return BadRequest ();
            }
            return Ok (new ApiResult<Server> (!result.IsError, result.Value));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<Server>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Deleted ([FromQuery] string id)
        {
            var result = await serverService.DeleteAsync(id);

            if(result.IsError)
            {
                return BadRequest ();
            }
            return Ok ();
        }
    }
}

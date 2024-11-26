using hiPower.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace hiPower.WebApi.Controllers
{
    [Route ("api/locations")]
    [ApiController]
    [Produces (MediaTypeNames.Application.Json)]
    public class LocationController(ILocationService locationService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type= typeof (ApiResult<IEnumerable<Location>>))]
        public async Task<IActionResult> GetAll()
        {
            var result = await locationService.GetAsync();

            if (result.IsError) 
            { 
                return BadRequest(new ApiResult<IEnumerable<Location>> (false, []));
            }

            var response = new ApiResult<IEnumerable<Location>>(true, result.Value);
            return Ok (response);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(ApiResult<Location>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Get ([FromRoute] string id)
        {
            var result = await locationService.GetAsync(id);

            if (result.IsError) 
            { 
                return BadRequest(new ProblemDetails () { Status = StatusCodes.Status400BadRequest });
            }
            return Ok (new ApiResult<Location> (true, result.Value));
        }

        [HttpGet ("{id}/servers")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<IEnumerable<Server>>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType (StatusCodes.Status404NotFound, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> GetServers ([FromRoute] string id)
        {
            var result = await locationService.GetServers (id);

            if (result.IsError)
            {
                return BadRequest (new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest
                });
            }

            var response = new ApiResult<IEnumerable<Server>>(true, result.Value);
            return Ok (response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResult<Location>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Create ([FromBody] Location location)
        {
            var result = await locationService.CreateAsync (location);

            if (result.IsError)
            {
                return BadRequest (new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest
                });
            }

            var response = new ApiResult<Location>(true, result.Value);

            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult<Location>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Update ([FromRoute] string id, [FromBody] Location location)
        {
            var result = await locationService.UpdateAsync(id, location);
            if (result.IsError)
            {
                return BadRequest (new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest
                });
            }

            var response = new ApiResult<Location>(true, result.Value);
            return Ok (response);
        }

        [HttpDelete ("id")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<bool>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType (StatusCodes.Status404NotFound, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Delete ([FromRoute] string id) 
        {
            var result = await locationService.DeleteAsync (id);
            if (result.IsError)
            {
                return BadRequest (new ProblemDetails ()
                {
                    Status = StatusCodes.Status400BadRequest
                });
            }
            var response = new ApiResult<bool>(true, result.Value);
            return Ok (response);
        }
    }
}

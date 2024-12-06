using hiPower.Abstracts;
using Microsoft.AspNetCore.Mvc;


namespace hiPower.WebApi.Controllers
{
    [Route ("api/datacenters")]
    [ApiController]
    [Produces (MediaTypeNames.Application.Json)]
    public class DataCentersController(IDataCenterService locationService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof (ApiResult<IEnumerable<DataCenter>>))]
        public async Task<IActionResult> GetAll()
        {
            var result = await locationService.GetAsync();

            if (result.IsError) 
            { 
                return BadRequest(new ApiResult<IEnumerable<DataCenter>> (false, []));
            }

            var response = new ApiResult<IEnumerable<DataCenter>>(true, result.Value);
            Thread.Sleep (1000);
            return Ok (response);
        }


        [HttpGet("{id}")]
        [ValidateIdFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult<DataCenter>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Get ([FromRoute] string id)
        {
            var result = await locationService.GetAsync(id);

            if (result.IsError) 
            { 
                if (result.FirstError.Type == ErrorType.NotFound)
                {
                    return NotFound();
                }
                return BadRequest();
            }
            Thread.Sleep (1000);
            return Ok (new ApiResult<DataCenter> (true, result.Value));
        }

        [HttpGet ("{id}/servers")]
        [ValidateIdFilter]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<IEnumerable<Dto.Manager.Server>>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType (StatusCodes.Status404NotFound, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> GetServers ([FromRoute] string id)
        {
            var result = await locationService.GetServers (id);

            if (result.IsError)
            {
                return BadRequest ();
            }

            var response = new ApiResult<IEnumerable<Dto.Manager.Server>>(true, result.Value);
            return Ok (response);
        }

        [HttpPost]
        [VallidatModel]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResult<DataCenter>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Create ([FromBody] DataCenter location)
        {
            var result = await locationService.CreateAsync (location);

            if (result.IsError)
            {
                return BadRequest ();
            }
            var temp = result.Value;
            var response = new ApiResult<DataCenter>(true, temp);

            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        [ValidateIdFilter]
        [VallidatModel]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult<DataCenter>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Update ([FromRoute] string id, [FromBody] DataCenter location)
        {
            var result = await locationService.UpdateAsync(id, location);
            if (result.IsError)
            {
                if (result.FirstError.Type == ErrorType.NotFound)
                {
                    return NotFound ();
                }
                return BadRequest ();
            }

            var response = new ApiResult<DataCenter>(true, result.Value);
            return Ok (response);
        }

        [HttpDelete ("{id}")]
        [ValidateIdFilter]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<bool>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        [ProducesResponseType (StatusCodes.Status404NotFound, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Delete ([FromRoute] string id) 
        {
            var result = await locationService.DeleteAsync (id);
            if (result.IsError)
            {
                if (result.FirstError.Type == ErrorType.NotFound)
                {
                    return NotFound () ;
                }
                return BadRequest ();
            }
            var response = new ApiResult<bool>(true, result.Value);
            return Ok (response);
        }
    }
}

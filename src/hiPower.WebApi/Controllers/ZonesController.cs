using hiPower.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace hiPower.WebApi.Controllers
{
    [Route ("api/zones")]
    [ApiController]
    [Produces (MediaTypeNames.Application.Json)]
    public class ZonesController(IZoneService zoneService) : ControllerBase
    {
        [HttpGet("{id}/zone/{zoneId}")]
        [ValidateIdFilter]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(ApiResult<object>))]
        public async Task<IActionResult> GetDetails ([FromRoute] string id, [FromRoute] string zoneId)
        {
            var result = await zoneService.GetDetailsAsync (id, zoneId);
            if (result.IsError && result.FirstError.Type == ErrorType.NotFound)
            {
                return NotFound (zoneId);
            }

            if (result.Value is null)
            {
                return NotFound (zoneId);
            }

            return Ok (new ApiResult<object>(!result.IsError, result.Value ));
        }

        [HttpGet("{id}")]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<object>))]
        public async Task<IActionResult> GetZones ([FromRoute] string id)
        {
            var result = await zoneService.GetListAsync (id);
            if (result.IsError && result.FirstError.Type == ErrorType.NotFound)
            {
                return NotFound ();
            }
            return Ok (new ApiResult<object> (!result.IsError, result.Value));
        }
    }
}

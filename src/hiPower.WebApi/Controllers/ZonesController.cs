using hiPower.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace hiPower.WebApi.Controllers
{
    [Route ("api/zones")]
    [ApiController]
    [Produces (MediaTypeNames.Application.Json)]
    public class ZonesController(IZoneService zoneService) : ControllerBase
    {
        [HttpGet("{zoneId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(ApiResult<object>))]
        public async Task<IActionResult> GetDetails ([FromRoute] string zoneId)
        {
            var result = await zoneService.GetDetailsAsync (zoneId);
            return Ok (new ApiResult<object>(!result.IsError, result.Value));
        }
    }
}

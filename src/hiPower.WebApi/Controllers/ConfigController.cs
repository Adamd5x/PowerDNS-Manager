using Microsoft.AspNetCore.Mvc;

using hiPower.Common.Type;

namespace hiPower.WebApi.Controllers
{
    [Route ("api/config")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ConfigController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult<IEnumerable<ConfigItem>>))]
        public IActionResult GetConfig()
        {

            ConfigItem[] endpoints = [
                new ConfigItem(EndpointType.Servers, "api/servers"),
                new ConfigItem(EndpointType.Zones, "api/zones"),
                new ConfigItem(EndpointType.Identity, "api/auth"),
                new ConfigItem(EndpointType.Locations, "api/locations"),
            ];

            return Ok (new ApiResult<IEnumerable<ConfigItem>>(true, endpoints));
        }
    }
}

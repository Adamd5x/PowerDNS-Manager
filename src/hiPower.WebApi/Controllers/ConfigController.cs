using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hiPower.WebApi.Controllers
{
    [Route ("api/config")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [AllowAnonymous]
    public class ConfigController(IConfiguration configuration) : ControllerBase
    {
        private readonly string licenseToken = configuration?.GetValue<string>("LicenseToken") ?? string.Empty;
        private readonly string userToken = configuration?.GetValue<string>("UserToken") ?? string.Empty;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult<StartupApp>))]
        public IActionResult GetConfig()
        {
            
            EndpointItem[] endpoints = [
                new EndpointItem(EndpointType.Servers, "api/servers"),
                new EndpointItem(EndpointType.Zones, "api/zones"),
                new EndpointItem(EndpointType.Identity, "api/auth"),
                new EndpointItem(EndpointType.DataCenters, "api/datacenters"),
            ];

            var startup = new StartupApp(licenseToken, userToken, 6000, endpoints);

            return Ok (new ApiResult<StartupApp> (true, startup));
        }
    }
}

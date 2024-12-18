﻿using hiPower.Abstracts;
using Mapster;
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
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<IEnumerable<Dto.Manager.Server>>))]
        public async Task<IActionResult> GetAll ([FromRoute] string dataCenterId)
        {
            var result = await serverService.GetAllAsync (dataCenterId);
            bool notFound = result.IsError && result.FirstError.Type == ErrorType.NotFound;

            if (notFound)
            {
                return NotFound ();
            }

            return Ok (new ApiResult<IEnumerable<Dto.Manager.Server>>(!result.IsError, result.Value));
        }


        [HttpGet ("{id}/server")]
        [ValidateIdFilter]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<Dto.Manager.Server>))]
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

            return Ok (new ApiResult<Dto.Manager.Server> (!result.IsError, result.Value));
        }

        [HttpGet("{id}/config")]
        [ValidateIdFilter]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<IEnumerable<SettingsItem>>))]
        [ProducesResponseType (StatusCodes.Status404NotFound, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> GetConfiguration ([FromRoute] string id)
        {
            var result = await serverService.GetRemoteConfigurationAsync (id);
            return Ok (new ApiResult<IEnumerable<SettingsItem>>(true, result.Value.Adapt<IEnumerable<SettingsItem>>()));
        }

        [HttpGet ("{id}/statistics")]
        [ValidateIdFilter]
        public async Task<IActionResult> GetStatistics ([FromRoute] string id)
        {
            var result = await serverService.GetRemoteStatisticsAsync (id);
            return Ok (result.Value);
        }        
        
        [HttpGet ("{id}/uptime")]
        [ValidateIdFilter]
        public async Task<IActionResult> GetUptime ([FromRoute] string id)
        {
            var result = await serverService.GetRemoteUptimeAsync (id);
            return Ok (result.Value);
        }

        [HttpGet ("{id}/info")]
        [ValidateIdFilter]
        public async Task<IActionResult> GetInfo ([FromRoute] string id)
        {
            var result = await serverService.GetRemoteServerInfoAsync (id);
            return Ok (result.Value);
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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResult<Dto.Manager.Server>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Create ([FromBody] Dto.Manager.Server server)
        {
            var result = await serverService.CreateAsync(server);
            return Created (string.Empty, new ApiResult<Dto.Manager.Server> (!result.IsError, result.Value));
        }

        [HttpPut ("{id}")]
        [ValidateIdFilter]
        [VallidatModel]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<Dto.Manager.Server>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Update ([FromRoute] string id, [FromBody] Dto.Manager.Server server)
        {
            var result = await serverService.UpdateAsync(id, server);
            bool notFound = result.IsError && result.FirstError.Type == ErrorType.NotFound;
            if (notFound)
            {
                return NotFound ();
            }
            return Ok (new ApiResult<Dto.Manager.Server> (!result.IsError, result.Value));
        }

        [HttpDelete("{id}")]
        [ValidateIdFilter]
        [ProducesResponseType (StatusCodes.Status200OK, Type = typeof (ApiResult<Dto.Manager.Server>))]
        [ProducesResponseType (StatusCodes.Status400BadRequest, Type = typeof (ProblemDetails))]
        public async Task<IActionResult> Deleted ([FromRoute] string id)
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

using Microsoft.AspNetCore.Mvc;

namespace hiPower.WebApi.Controllers
{
    [Route ("api/auth")]
    [ApiController]
    [Produces (MediaTypeNames.Application.Json)]
    public class AuthController(ILogger<AuthController> logger) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResult<AppUser>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        public IActionResult SignIn ([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest.Username.Equals("string", StringComparison.OrdinalIgnoreCase) || loginRequest.Password.Equals("string", StringComparison.OrdinalIgnoreCase)) 
            {
                return BadRequest ();
            }

            logger.LogInformation ("Try login with: userName: {UserName}, password: {Pwd}", loginRequest.Username, loginRequest.Password);
            return Ok (new ApiResult<AppUser>(true, new AppUser ("2ae77ae6-acba-11ef-a6ba-85e7a48fa0c0", "John Doe", "jdoe@example.com")));
        }
    }
}

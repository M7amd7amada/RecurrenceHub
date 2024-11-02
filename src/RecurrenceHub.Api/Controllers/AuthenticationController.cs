using Microsoft.AspNetCore.Mvc;

using RecurrenceHub.Contracts.Authentication;

namespace RecurrenceHub.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost(nameof(Register))]
    public ActionResult<AuthenticationResponse> Register(RegisterRequest request)
    {
        return Ok(request);
    }

    [HttpPost(nameof(Login))]
    public ActionResult<AuthenticationResponse> Login(LoginRequest request)
    {
        return Ok(request);
    }
}

using Microsoft.AspNetCore.Mvc;

using RecurrenceHub.Application.Services.Authentication;
using RecurrenceHub.Contracts.Authentication;

namespace RecurrenceHub.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController(IAuthenticationService service) : ControllerBase
{
    [HttpPost(nameof(Register))]
    public ActionResult<AuthenticationResponse> Register(RegisterRequest request)
    {
        // ! Proper Handling this latter
        ArgumentNullException.ThrowIfNull(request);
        var result = service.Register(request.FirstName, request.LastName, request.Email, request.Password);
        return Ok(new AuthenticationResponse(result.UserId, result.FirstName, result.LastName, result.Email, result.Token));
    }

    [HttpPost(nameof(Login))]
    public ActionResult<AuthenticationResponse> Login(LoginRequest request)
    {
        // ! Proper Handling this latter
        ArgumentNullException.ThrowIfNull(request);
        var result = service.Login(request.Email, request.Password);
        return Ok(new AuthenticationResponse(result.UserId, result.FirstName, result.LastName, result.Email, result.Token));
    }
}

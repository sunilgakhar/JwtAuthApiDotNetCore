using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    // This endpoint is public and does not require authorization
    [HttpGet("public")]
    public IActionResult PublicEndpoint()
    {
        return Ok(AppConfigMessages.PublicEndPoint);
    }

    // This endpoint requires a valid JWT token to access
    [Authorize]
    [HttpGet("protected")]
    public IActionResult ProtectedEndpoint()
    {
        return Ok(AppConfigMessages.ProtectedEndPoint);
    }

}

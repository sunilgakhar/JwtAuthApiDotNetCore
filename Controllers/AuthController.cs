using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (IsValidUser(request.Username, request.Password, out var userId, out var role))
        {
            var token = _authService.GenerateJwtToken(userId, request.Username, role);
            return Ok(new { Token = token });
        }

        return Unauthorized(AppConfigMessages.InvalidCredentials);
    }

    private bool IsValidUser(string username, string password, out string userId, out string role)
    {
        if (username == "testuser" && password == "password")
        {
            userId = "1";
            role = "User";
            return true;
        }

        userId = string.Empty;
        role = string.Empty;
        return false;
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

using Microsoft.AspNetCore.Mvc;
using PetshopAPISystem.Api.DTOs.Requests;
using PetshopAPISystem.Domain.Models;
using PetshopAPISystem.Domain.Services;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{

    public readonly AuthService AuthService;

    public AuthController(AuthService authService)
    {
        AuthService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register( Tutor tutor)
    {
        var newTutor = await AuthService.Register(tutor);
        if (newTutor == null) return Conflict("Email Already Registered");
        return Ok("Registration Successful");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(TutorLoginRequestDTO loginRequest)
    {
        var token = await AuthService.Login(loginRequest);
        if (token == null) return Unauthorized("Something went wrong while logging in, please verify email and password");
        return Ok(token);
    }
}
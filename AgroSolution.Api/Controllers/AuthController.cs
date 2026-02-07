using AgroSolution.Core.App.DTO;
using AgroSolution.Core.App.Features.Auth;
using AgroSolution.Core.App.Features.Register;
using Microsoft.AspNetCore.Mvc;

namespace AgroSolution.Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;
    private readonly IRegisterService _registerService;

    public AuthController(IAuthService authService, IRegisterService registerService)
    {
        _authService = authService;
        _registerService = registerService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var result = await _registerService.Register(registerDto);
        return CustomResponse(result);
        
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var result = await _authService.Login(loginDto);
        return CustomResponse(result);
    }
}
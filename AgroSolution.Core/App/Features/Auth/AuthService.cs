using AgroSolution.Core.App.Common;
using AgroSolution.Core.App.DTO;
using AgroSolution.Core.App.Features.TokenJwt;
using AgroSolution.Core.Domain.Interfaces;

namespace AgroSolution.Core.App.Features.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<Result<UserTokenDto>> Login(LoginDto loginDto)
    {
        var user = await _userRepository.FindByEmailAsync(loginDto.Email);
        
        if (user == null || !await _userRepository.CheckPasswordAsync(user, loginDto.Password))
        {
            return Result<UserTokenDto>.Fail("Invalid credentials.");
        }
        
        var tokenData = _tokenService.GenerateToken(user);
        
        return Result<UserTokenDto>.Ok(tokenData);
    }
}
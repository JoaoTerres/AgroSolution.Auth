using AgroSolution.Core.App.Common;
using AgroSolution.Core.App.DTO;

namespace AgroSolution.Core.App.Features.Auth;

public interface IAuthService
{
    Task<Result<UserTokenDto>> Login(LoginDto loginDto);
}
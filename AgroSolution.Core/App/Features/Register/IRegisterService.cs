using AgroSolution.Core.App.Common;
using AgroSolution.Core.App.DTO;

namespace AgroSolution.Core.App.Features.Register;

public interface IRegisterService
{
    Task<Result<string>> Register(RegisterDto registerDto);
}
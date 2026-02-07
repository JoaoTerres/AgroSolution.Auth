using AgroSolution.Core.App.Common;
using AgroSolution.Core.App.DTO;
using AgroSolution.Core.Domain;
using AgroSolution.Core.Domain.Interfaces;

namespace AgroSolution.Core.App.Features.Register;

public class RegisterService : IRegisterService
{
    private readonly IUserRepository _userRepository;

    public RegisterService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<string>> Register(RegisterDto registerDto)
    {
        var user = new User(registerDto.FullName, registerDto.Email);

        var result = await _userRepository.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            var error = result.Errors.FirstOrDefault()?.Description ?? "Registration failed";
            return Result<string>.Fail(error);
        }

        return Result<string>.Ok("Producer registered successfully.");
    }
}
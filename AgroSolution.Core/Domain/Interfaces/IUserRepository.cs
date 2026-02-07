using Microsoft.AspNetCore.Identity;

namespace AgroSolution.Core.Domain.Interfaces;

public interface IUserRepository
{
    Task<IdentityResult> CreateAsync(User user, string password);
    Task<User?> FindByEmailAsync(string email);
    Task<bool> CheckPasswordAsync(User user, string password);
}
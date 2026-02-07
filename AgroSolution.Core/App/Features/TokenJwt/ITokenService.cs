using AgroSolution.Core.App.DTO;
using AgroSolution.Core.Domain;

namespace AgroSolution.Core.App.Features.TokenJwt;

public interface ITokenService
{
    UserTokenDto GenerateToken(User user);
}
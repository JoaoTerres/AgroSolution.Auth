namespace AgroSolution.Core.App.DTO;

public record UserTokenDto(
    string Email, 
    string Token, 
    DateTime Expiration,
    string FullName
);
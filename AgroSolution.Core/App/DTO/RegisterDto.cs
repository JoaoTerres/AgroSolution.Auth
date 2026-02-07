namespace AgroSolution.Core.App.DTO;

public record RegisterDto(
    string FullName, 
    string Email, 
    string Password,
    string ConfirmPassword 
);
using Microsoft.AspNetCore.Identity;

namespace AgroSolution.Core.Domain;

public class User : IdentityUser
{
    public string FullName { get; private set; }

    protected User() { }

    public User(string fullName, string email)
    {
        Validate(fullName, email);
        
        FullName = fullName;
        UserName = email; 
        Email = email;
    }

    private void Validate(string fullName, string email)
    {
        AssertValidation.ValidateIfEmpty(fullName, "Full name is required.");
        AssertValidation.ValidateMinimumLength(fullName, 3, "Full name is too short.");
        AssertValidation.ValidateEmailFormat(email, "Invalid email format.");
    }
}
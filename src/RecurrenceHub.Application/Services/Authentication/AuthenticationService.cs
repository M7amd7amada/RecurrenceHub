using RecurrenceHub.Application.Common.Interfaces;

namespace RecurrenceHub.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator tokenGenerator) : IAuthenticationService
{
    private readonly List<string> _users = [];
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "Firstname",
            "LastName",
            email,
            password);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // check if the user exist
        // ! handle it proper in the future.
        if (_users.Exists(x => string.Equals(x, email, StringComparison.Ordinal)))
        {
            throw new InvalidOperationException();
        }

        // create new user
        _users.Add(email);

        // Genearte jwt token
        var userId = Guid.NewGuid();
        var token = tokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult(
            userId,
            firstName,
            lastName,
            email,
            token);
    }
}

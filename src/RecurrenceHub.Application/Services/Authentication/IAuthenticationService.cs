namespace RecurrenceHub.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Register(string request);
    AuthenticationResult Login(string request);
}
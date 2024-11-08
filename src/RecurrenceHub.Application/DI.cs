using Microsoft.Extensions.DependencyInjection;

using RecurrenceHub.Application.Services.Authentication;

namespace RecurrenceHub.Application;

public static class DI
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
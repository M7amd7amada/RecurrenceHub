using Microsoft.Extensions.DependencyInjection;

using RecurrenceHub.Application.Common.Interfaces.Authentication;
using RecurrenceHub.Infrastructure.Common.Authentication;

namespace RecurrenceHub.Infrastructure;

public static class DI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}
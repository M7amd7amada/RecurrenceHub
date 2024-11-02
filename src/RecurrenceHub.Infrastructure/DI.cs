using Microsoft.Extensions.DependencyInjection;

using RecurrenceHub.Application.Common.Interfaces.Authentication;
using RecurrenceHub.Application.Common.Interfaces.Services;
using RecurrenceHub.Infrastructure.Authentication;
using RecurrenceHub.Infrastructure.Services;

namespace RecurrenceHub.Infrastructure;

public static class DI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
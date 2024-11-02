using Microsoft.Extensions.DependencyInjection;

using RecurrenceHub.Application.Common.Interfaces;
using RecurrenceHub.Infrastructure.Common;

namespace RecurrenceHub.Infrastructure;

public static class DI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}
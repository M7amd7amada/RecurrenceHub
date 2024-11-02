using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using RecurrenceHub.Application.Common.Interfaces.Authentication;
using RecurrenceHub.Application.Common.Interfaces.Services;
using RecurrenceHub.Infrastructure.Authentication;
using RecurrenceHub.Infrastructure.Services;

namespace RecurrenceHub.Infrastructure;

public static class DI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddServices();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
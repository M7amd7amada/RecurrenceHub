using Microsoft.Extensions.DependencyInjection;

namespace RecurrenceHub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        return services;
    }
}
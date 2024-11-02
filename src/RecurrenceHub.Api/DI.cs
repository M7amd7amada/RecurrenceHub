namespace RecurrenceHub.Api;

public static class DI
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.ConfigureOpenApi();
        services.AddControllers();

        return services;
    }
}
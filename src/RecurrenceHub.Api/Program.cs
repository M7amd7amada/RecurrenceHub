var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApi()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync().ConfigureAwait(false);

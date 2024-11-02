var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync().ConfigureAwait(false);

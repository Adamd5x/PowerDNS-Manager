using hiPower.Core.Extensions.DependencyInjection;
using hiPower.Database.Extensions.DependencyInjection;
using hiPower.Infrastructure.Extensions.DependencyInjection;
using hiPower.WebApi.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program> ();
builder.Host.ConfigureHost ();

builder.Services.ConfigureWebHostServices (builder.Configuration)
                .ConfigureDbRepository (builder.Configuration)
                .ConfigureCoreServices ()
                .ConfigureInfrastructureServices(builder.Configuration);

var app = builder.Build();

await app.Services.UseManagerSeederAsync ();

if (app.Environment.IsDevelopment ())
{
    app.UseSwagger ();
    app.UseSwaggerUI ();
}

app.UseHttpsRedirection ();

app.UseExceptionHandler(_ => { });

app.UseAuthorization ();
app.MapControllers ();

await app.RunAsync ();

public partial class Program() { }